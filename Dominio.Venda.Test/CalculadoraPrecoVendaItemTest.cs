using Xunit;

namespace Dominio.Venda.Test
{
    public class CalculadoraPrecoVendaItemTest
    {
        [Fact]
        public void TestCriarCalculadora()
        {
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem(
                quantidadeVendida: 1.5M,
                valorUnitario: 1.5M,
                quantidadePromocional: 1.5M,
                valorPromocional: 1.5M);

            Assert.NotNull(calculadoraPrecoVendaItem);
        }
    }
}