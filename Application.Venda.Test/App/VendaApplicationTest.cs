using Application.Venda.App;
using Application.Venda.App.Impl;
using CrossCutting.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.Venda.Test.App
{
    public class VendaApplicationTest
    {
        [Fact]
        public void EhPossivelCriarVendaApplication()
        {
            IVendaApplication vendaApplication = new VendaApplication();

            Assert.NotNull(vendaApplication);
        }

        [Fact]
        public void DeveProcessarAVenda()
        {
            IVendaApplication vendaApplication = new VendaApplication();
            var vendaDTO = PegarVendaDTO();
            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.True(vendaEfetuadaComSucesso);
        }

        private VendaDTO PegarVendaDTO()
        {
            return new VendaDTO()
            {
                Cliente = new ClienteDTO("CLiente"),
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
