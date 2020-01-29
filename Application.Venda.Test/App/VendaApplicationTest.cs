using Application.Venda.App;
using Application.Venda.App.Impl;
using Application.Venda.Factories.Impl;
using Application.Venda.Models;
using Application.Venda.Modules;
using Dominio.Venda.Services;
using CrossCutting.Models;
using System.Collections.Generic;
using Xunit;
using Moq;
using Dominio.Venda.Entities;
using AutoMapper;

namespace Application.Venda.Test.App
{
    public class VendaApplicationTest
    {
        [Fact]
        public void EhPossivelCriarVendaApplication()
        {
            var salvarVendaService = new Mock<ISalvarVendaService>();
            IMapper mapper = PegarMapper();
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(mapper), salvarVendaService.Object);

            Assert.NotNull(vendaApplication);
        }

        [Fact]
        public void DeveProcessarAVenda()
        {
            var salvarVendaService = new Mock<ISalvarVendaService>();
            salvarVendaService
                .Setup(s => s.Executar(It.IsAny<VendaEntity>()))
                .Returns(true);
            IMapper mapper = PegarMapper();
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(mapper), salvarVendaService.Object);
            var vendaDTO = PegarVendaDTO();

            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.True(vendaEfetuadaComSucesso);
        }

        [Fact]
        public void NaoProcessaQuandoServiceRetornaFalso()
        {
            var mensagemDeErro = new List<MensagemErro> {
                new MensagemErro("Mensagem de erro")
            };
            var salvarVendaService = new Mock<ISalvarVendaService>(MockBehavior.Strict);
            salvarVendaService
                .Setup(s => s.Executar(It.IsAny<VendaEntity>()))
                .Returns(false);
            salvarVendaService
                .Setup(s => s.PegarMensagensErro())
                .Returns(mensagemDeErro);
            var vendaDTO = PegarVendaDTO();
            IMapper mapper = PegarMapper();
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(mapper), salvarVendaService.Object);

            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.False(vendaEfetuadaComSucesso);
        }

        [Fact]
        public void DeveRetornarTodasAsMensagensDeErroDoService()
        {
            IEnumerable<MensagemErro> listaDeErros = new List<MensagemErro> {
                new MensagemErro("Mensagem de erro 1"),
                new MensagemErro("Mensagem de erro 2")
            };
            var salvarVendaService = new Mock<ISalvarVendaService>(MockBehavior.Strict);
            salvarVendaService
                .Setup(s => s.Executar(It.IsAny<VendaEntity>()))
                .Returns(false);
            salvarVendaService
                .Setup(s => s.PegarMensagensErro())
                .Returns(listaDeErros);
            var vendaDTO = PegarVendaDTO();
            IMapper mapper = PegarMapper();
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(mapper), salvarVendaService.Object);

            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);
            var listaDeErrosEncontrados = vendaApplication.PegarMensagensErro();

            Assert.False(vendaEfetuadaComSucesso);
            Assert.Equal(listaDeErros, listaDeErrosEncontrados);
        }

        private VendaModel PegarVendaDTO()
        {
            return new VendaModel()
            {
                Cliente = new ClienteModel("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro,
                Itens = new List<VendaItemModel>{
                    new VendaItemModel{
                        Descricao = "Produto",
                        QuantidadeComprada = 10,
                        QuantidadePromocional = 20,
                        ValorUnitario = 10,
                        ValorUnitarioPromocional = 5
                    }
                }
            };
        }

        private IMapper PegarMapper()
        {
            return AutoMapperConfig.PegarMapper();
        }
    }
}
