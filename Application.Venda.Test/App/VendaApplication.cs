using System;
using Xunit;

namespace Application.Venda.Test.App
{
    public class VendaApplication
    {
        [Fact]
        public void EhPossivelCriarVendaApplication()
        {
            IVendaApplication vendaApplication = new VendaApplication();

            Assert.NotNull(vendaApplication);
        }
    }
}
