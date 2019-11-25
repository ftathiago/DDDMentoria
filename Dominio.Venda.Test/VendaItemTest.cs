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
                descricao: "Produto",
                quantidadeComprada: 1,
                valorUnitario: valorEsperado);
            VendaItem vendaItem = new VendaItem(produtoVendido);

            decimal valorExposto = vendaItem.ValorUnitario;

            Assert.Equal(valorEsperado, valorExposto);
        }

        [Fact]
        public void TestVendaItemExpoeValorPromocional()
        {
            decimal valorEsperado = 10.5M;
            ProdutoVendido produtoVendido = ProdutoVendidoFactory(
                descricao: "Produto",
                quantidadeComprada: 1,
                valorUnitario: 0,
                valorUnitarioPromocional: valorEsperado);
            VendaItem vendaItem = new VendaItem(produtoVendido);

            decimal valorEsposto = vendaItem.ValorUnitarioPromocional;

            Assert.Equal(valorEsperado, valorEsposto);
        }

        [Fact]
        public void TestVendaItemCalculaTotalItem()
        {
            decimal valorEsperado = 5M;
            ProdutoVendido produtoVendido = ProdutoVendidoFactory(
                descricao: "Produto",
                quantidadeComprada: 0.5M,
                valorUnitario: 10M);
            VendaItem vendaItem = new VendaItem(produtoVendido);

            decimal totalItem = vendaItem.TotalItem();

            Assert.Equal(valorEsperado, totalItem);
        }

        [Fact]
        public void TestVendaItemCalculaTotalPromocional()
        {
            decimal valorEsperado = 2.5M;
            ProdutoVendido produtoVendido = ProdutoVendidoFactory(
                descricao: "Produto",
                quantidadeComprada: 0.5M,
                quantidadePromocional: 0.5M,
                valorUnitario: 10M,
                valorUnitarioPromocional: 5M);
            VendaItem vendaItem = new VendaItem(produtoVendido);

            decimal totalItem = vendaItem.TotalItem();

            Assert.Equal(valorEsperado, totalItem);
        }

        private ProdutoVendido ProdutoVendidoFactory(string descricao, decimal quantidadeComprada, decimal valorUnitario, decimal quantidadePromocional = -1, decimal valorUnitarioPromocional = -1)
        {
            return new ProdutoVendido
            {
                Descricao = descricao,
                QuantidadeComprada = quantidadeComprada,
                ValorUnitario = valorUnitario,
                QuantidadePromocional = quantidadePromocional,
                ValorUnitarioPromocional = valorUnitarioPromocional
            };
        }
    }
}