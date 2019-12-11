using Xunit;

namespace Dominio.Venda.Test.ValueObjects
{
    public class ValorUnitarioTest
    {
        [Fact]
        public void TestCriarValorUnitario()
        {
            var valorUnitario = new ValorUnitario(10.01M);

            Assert.NotNull(valorUnitario);
        }
    }
}