using Xunit;

namespace Dominio.Venda.Test
{
    public class VendaFactoryTest
    {
        [Fact]
        public void TestCriarFabrica()
        {
            IVendaFactory vendaFactory = new VendaFactory();
            vendaDTO = new VendaDTO();

            Venda venda = vendaFactory.Criar(vendaDTO);

            Assert.NotNull(venda);
            Assert.IsAssignableFrom<Venda>(venda);
        }
    }
}