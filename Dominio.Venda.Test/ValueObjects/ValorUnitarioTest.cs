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

        [Fact]
        public void TestValorUnitarioValido()
        {
            ValorUnitario valorUnitario = new ValorUnitario(0.01M);

            bool estaValido = valorUnitario.Validar();

            Assert.True(estaValido);
        }
    }
}