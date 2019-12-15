using Application.Venda.App;
using Application.Venda.App.Impl;
using Application.Venda.Factories.Impl;
using Dominio.Venda.Services;
using CrossCutting.Models;
using System.Collections.Generic;
using Xunit;
using Moq;
using Dominio.Venda.Entities;

namespace Application.Venda.Test.App
{
    public class VendaApplicationTest
    {
        [Fact]
        public void EhPossivelCriarVendaApplication()
        {
            var salvarVendaService = new Mock<ISalvarVendaService>();
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(), salvarVendaService.Object);

            Assert.NotNull(vendaApplication);
        }

        [Fact]
        public void DeveProcessarAVenda()
        {
            var salvarVendaService = new Mock<ISalvarVendaService>();
            salvarVendaService
                .Setup(s => s.Executar(It.IsAny<VendaEntity>()))
                .Returns(true);
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(), salvarVendaService.Object);
            var vendaDTO = PegarVendaDTO();

            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.True(vendaEfetuadaComSucesso);
        }

        [Fact]
        public void NaoProcessaQuandoServiceRetornaFalso()
        {
            var salvarVendaService = new Mock<ISalvarVendaService>();
            salvarVendaService
                .Setup(s => s.Executar(It.IsAny<VendaEntity>()))
                .Returns(false);
            var vendaDTO = PegarVendaDTO();
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(), salvarVendaService.Object);

            bool vendaEfetuuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.False(vendaEfetuuadaComSucesso);
        }

        private VendaDTO PegarVendaDTO()
        {
            return new VendaDTO()
            {
                Cliente = new ClienteDTO("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro,
                Itens = new List<VendaItemDTO>{
                    new VendaItemDTO{
                        Descricao = "Produto",
                        QuantidadeComprada = 10,
                        QuantidadePromocional = 20,
                        ValorUnitario = 10,
                        ValorUnitarioPromocional = 5
                    }
                }
            };
        }
    }
}
