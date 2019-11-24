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

        private ProdutoVendido ProdutoVendidoFactory(string Descricao, int QuantidadeComprada, int ValorUnitario, decimal quantidadePromocional = -1, decimal valorUnitarioPromocional = -1)
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