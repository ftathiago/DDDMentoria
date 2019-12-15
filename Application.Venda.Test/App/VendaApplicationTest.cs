using Application.Venda.App;
using Application.Venda.App.Impl;
using CrossCutting.Models;
using System;
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
            var vendaDTO = new VendaDTO();

            bool vendaEfetuadaComSucesso = vendaApplication.ProcessarVenda(vendaDTO);

            Assert.True(vendaEfetuadaComSucesso);
        }
    }
}
