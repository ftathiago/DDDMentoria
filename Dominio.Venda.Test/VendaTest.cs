using System;
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
            var produto = ProdutoVendidoFactory("Produto1", 1, 1);
            venda.AdicionarProduto(produto);

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
            ProdutoVendido produtoVendido = ProdutoVendidoFactory("Produto", 0, 1);
            venda.AdicionarProduto(produtoVendido);

            bool vendaEhValida = venda.Validar();
            int totalVendido = venda.TotalVenda();

            Assert.False(vendaEhValida);
            Assert.Equal(0, totalVendido);
        }

        [Fact]
        public void TestVendaCalculaTotalProdutos()
        {
            ProdutoVendido produtoVendido1 = ProdutoVendidoFactory("Produto1", 1, 2);
            ProdutoVendido produtoVendido2 = ProdutoVendidoFactory("Produto2", 2, 1);
            Venda venda = VendaFactory();
            venda.AdicionarProduto(produtoVendido1);
            venda.AdicionarProduto(produtoVendido2);

            var totalVenda = venda.TotalVenda();

            Assert.Equal(4, totalVenda);
        }

        private Venda VendaFactory()
        {
            return new Venda("Cliente");
        }

        private ProdutoVendido ProdutoVendidoFactory(string Descricao, int QuantidadeComprada, int ValorUnitario)
        {
            return new ProdutoVendido
            {
                Descricao = Descricao,
                QuantidadeComprada = QuantidadeComprada,
                ValorUnitario = ValorUnitario
            };
        }
    }
}
