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

        [Fact]
        public void TestAtribuicaoDireita()
        {
            const decimal quantidadeEsperada = 10.001M;
            Quantidade quantidade = quantidadeEsperada;

            Assert.Equal(quantidadeEsperada, quantidade.Value);
        }

    }
}