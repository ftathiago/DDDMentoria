using Xunit;

namespace Dominio.Venda.Test
{
    public class VendaItemTest
    {
        [Fact]
        public void TestCriarVendaItem()
        {
            ProdutoVendido produtoVendido = ProdutoVendidoFactory("Produto", 1, 10);

            VendaItem vendaItem = new VendaItem(produtoVendido);

            Assert.NotNull(vendaItem);
        }

        [Fact]
        public void TestVendaItemTemDescricaoImutavel()
        {
            string descricaoEsperada = "Produto";
            ProdutoVendido produtoVendido = ProdutoVendidoFactory(descricaoEsperada, 1, 10);
            VendaItem vendaItem = new VendaItem(produtoVendido);

            var vendaItemDescricao = vendaItem.Descricao;
            vendaItemDescricao = "Descrição alterada";

            Assert.Equal(descricaoEsperada, vendaItem.Descricao);
        }

        [Fact]
        public void TestVendaItemExpoeValorUnitarioNormal()
        {
            decimal valorEsperado = 10.5M;
            ProdutoVendido produtoVendido = ProdutoVendidoFactory(
                Descricao: "Produto",
                QuantidadeComprada: 1,
                ValorUnitario: valorEsperado);
            VendaItem vendaItem = new VendaItem(produtoVendido);

            decimal valorExposto = vendaItem.ValorUnitario;

            Assert.Equal(valorEsperado, valorExposto);
        }

        private ProdutoVendido ProdutoVendidoFactory(string Descricao, int QuantidadeComprada, decimal ValorUnitario, decimal quantidadePromocional = -1, decimal valorUnitarioPromocional = -1)
        {
            return new ProdutoVendido
            {
                Descricao = Descricao,
                QuantidadeComprada = QuantidadeComprada,
                ValorUnitario = ValorUnitario,
                QuantidadePromocional = quantidadePromocional,
                ValorUnitarioPromocional = valorUnitarioPromocional
            };
        }
    }
}