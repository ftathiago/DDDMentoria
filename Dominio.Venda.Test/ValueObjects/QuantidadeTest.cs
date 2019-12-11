using Dominio.Venda.ValueObjects;
using Xunit;

namespace Dominio.Venda.Test.ValueObjects
{
    public class QuantidadeTest
    {
        [Fact]
        public void TestCriarQuantidade()
        {
            Quantidade quantidade = new Quantidade(0.001M);

            Assert.NotNull(quantidade);
        }
    }
}