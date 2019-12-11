using Xunit;
using Dominio.Venda.ValueObjects;

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

        [Fact]
        public void TestAtribuicaoDireita()
        {
            const decimal valorEsperado = 10.00M;
            ValorUnitario valorUnitario = valorEsperado;

            Assert.Equal(valorEsperado, valorUnitario.Value);
        }
    }
}