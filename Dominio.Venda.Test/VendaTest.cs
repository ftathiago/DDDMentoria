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
            venda.AdicionarProduto("Produto", 1, 2);

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
        public void TestVendaCalculaTotalProdutos()
        {
            Venda venda = VendaFactory();
            venda.AdicionarProduto("Produto", 1, 2);
            var totalVenda = venda.TotalVenda();

            Assert.Equal(2, totalVenda);
        }
        private Venda VendaFactory()
        {
            return new Venda("Cliente");
        }
    }
}
