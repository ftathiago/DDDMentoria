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
        As formas de pagamento possíveis são:
            - Dinheiro
            - Vale Alimentação
            - Débito
            - Crédito
            - Cheque
        Cada produto possui uma "Quantidade de promoção" que caso sejam vendidos produtos suficientes, será aplicado o valor promocional
            Cada produto possui uma "Quantidade de promoção" que caso sejam vendidos produtos suficientes, será aplicado o valor promocional
            O valor promocional somente será aplicado para pagamentos:
                - Em dinheiro
                - Cartão de débito
                - Vale Alimentação
            Nos demais casos, será feito o cálculo normal.
        A venda só pode ser concluida após o pagamento ser aprovado
        A venda pode ter vários métodos de pagamento
        */
        [Theory]
        [InlineData(FormaDePagamento.None)]
        [InlineData(FormaDePagamento.Dinheiro)]
        public void TestCriarVendaComFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            string cliente = "Cliente";

            Venda venda = new Venda("Cliente", formaDePagamento);

            Assert.Equal(formaDePagamento, venda.FormaDePagamento);
            Assert.Equal("Cliente", cliente);
        }

        [Fact]
        public void TestVendaEhValidaComUmProdutoAoMenos()
        {
            Venda venda = VendaFactory(FormaDePagamento.Dinheiro);
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

        [Theory]
        [InlineData(FormaDePagamento.Dinheiro)]
        [InlineData(FormaDePagamento.ValeAlimentacao)]
        [InlineData(FormaDePagamento.Debito)]
        public void TestVendaCalculaTotalPromocionalDoProduto(FormaDePagamento formaDePagamento)
        {
            decimal totalEsperado = 5M;
            var vendaItem = VendaItemFactory(
                    Descricao: "Produto Promocional",
                    QuantidadeComprada: 10,
                    ValorUnitario: 1,
                    quantidadePromocional: 9.9M,
                    valorUnitarioPromocional: 0.5M);
            Venda venda = VendaFactory(formaDePagamento);
            venda.AdicionarVendaItem(vendaItem);

            var totalVenda = venda.TotalVenda();

            Assert.Equal(totalEsperado, totalVenda);
        }

        [Theory]
        [InlineData(FormaDePagamento.Cheque)]
        [InlineData(FormaDePagamento.Credito)]
        [InlineData(FormaDePagamento.None)]
        public void TestNaoCalcularValorPromocionalParaFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            decimal totalEsperado = 10M;
            var vendaItem = VendaItemFactory(
                    Descricao: "Produto Promocional",
                    QuantidadeComprada: 10,
                    ValorUnitario: 1,
                    quantidadePromocional: 9.9M,
                    valorUnitarioPromocional: 0.5M);
            Venda venda = VendaFactory(formaDePagamento);
            venda.AdicionarVendaItem(vendaItem);

            var totalVenda = venda.TotalVenda();

            Assert.Equal(totalEsperado, totalVenda);
        }

        private Venda VendaFactory(FormaDePagamento formaDePagamento = FormaDePagamento.None)
        {
            return new Venda("Cliente", formaDePagamento);
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
