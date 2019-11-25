using Xunit;
using Dominio.Venda;

namespace Dominio.Venda.Test
{
    public class VendaTest
    {
        /* 
        Toda venda tem um cliente
        A venda, para ser válida, 
            precisa possuir ao menos um produto
            O valor total precisa ser maior que zero (qtd * vlrUnitario || vlrPromocional)
        Cada produto possui uma "Quantidade de promoção" que caso sejam vendidos produtos suficientes, será aplicado o valor promocional
        A venda só pode ser concluida após o pagamento ser aprovado
        A venda pode ter vários métodos de pagamento
        */
        [Fact]
        public void TestCriarVenda()
        {
            Venda venda = VendaFactory();
            var cliente = venda.Cliente;
            Assert.Equal("Cliente", cliente);
        }

        [Fact]
        public void TestVendaEhValidaComUmProdutoAoMenos()
        {
            Venda venda = VendaFactory();
            var produto = VendaItemFactory("Produto1", 1, 1);
            venda.AdicionarVendaItem(produto);

            bool vendaEhValida = venda.Validar();

            Assert.True(vendaEhValida);
        }

        [Fact]
        public void TestVendaNaoEhValidaSemProdutos()
        {
            Venda venda = VendaFactory();

            bool vendaEhValida = venda.Validar();

            Assert.False(vendaEhValida);
        }

        [Fact]
        public void TestVendaNaoEhValidaComTotalMenorIgualZero()
        {
            Venda venda = VendaFactory();
            var vendaItem = VendaItemFactory("Produto", 0, 1);
            venda.AdicionarVendaItem(vendaItem);

            bool vendaEhValida = venda.Validar();
            decimal totalVendido = venda.TotalVenda();

            Assert.False(vendaEhValida);
            Assert.Equal(0, totalVendido);
        }

        [Fact]
        public void TestVendaCalculaTotalProdutos()
        {
            var vendaItem1 = VendaItemFactory("Produto1", 1, 2);
            var vendaItem2 = VendaItemFactory("Produto2", 2, 1);
            Venda venda = VendaFactory();
            venda.AdicionarVendaItem(vendaItem1);
            venda.AdicionarVendaItem(vendaItem2);

            var totalVenda = venda.TotalVenda();

            Assert.Equal(4, totalVenda);
        }

        [Fact]
        public void TestVendaCalculaTotalPromocionalDoProduto()
        {
            decimal totalEsperado = 5M;
            var vendaItem = VendaItemFactory(
                    Descricao: "Produto Promocional",
                    QuantidadeComprada: 10,
                    ValorUnitario: 1,
                    quantidadePromocional: 9.9M,
                    valorUnitarioPromocional: 0.5M);
            Venda venda = VendaFactory();
            venda.AdicionarVendaItem(vendaItem);

            var totalVenda = venda.TotalVenda();

            Assert.Equal(totalEsperado, totalVenda);
        }


        private Venda VendaFactory()
        {
            return new Venda("Cliente");
        }

        private VendaItem VendaItemFactory(string Descricao, int QuantidadeComprada, int ValorUnitario, decimal quantidadePromocional = -1, decimal valorUnitarioPromocional = -1)
        {
            var produtoVendido = new ProdutoVendido
            {
                Descricao = Descricao,
                QuantidadeComprada = QuantidadeComprada,
                ValorUnitario = ValorUnitario,
                QuantidadePromocional = quantidadePromocional,
                ValorUnitarioPromocional = valorUnitarioPromocional
            };
            return new VendaItem(produtoVendido);
        }
    }
}
