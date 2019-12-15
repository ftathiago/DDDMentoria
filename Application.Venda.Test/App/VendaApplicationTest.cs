using Application.Venda.App;
using Application.Venda.App.Impl;
using Application.Venda.Factories.Impl;
using Dominio.Venda.Services;
using CrossCutting.Models;
using System.Collections.Generic;
using Xunit;
using Moq;

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
            IVendaApplication vendaApplication = new VendaApplication(new VendaFactory(), salvarVendaService.Object);
            var vendaDTO = PegarVendaDTO();

            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.True(vendaEfetuadaComSucesso);
        }

        [Fact]
        public void DeveEnviarParaOService()
        {
            //Given

            //When

            //Then
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
