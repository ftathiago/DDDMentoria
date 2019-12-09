using Xunit;

namespace Dominio.Venda.Test
{
    /*
        Para não haver overhead de criação/destruição de objetos, a instância de 
        calculadora deverá ser reaproveitável
    */
    public class CalculadoraPrecoVendaItemTest
    {
        [Fact]
        public void TestCriarCalculadora()
        {
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem();

            Assert.NotNull(calculadoraPrecoVendaItem);
        }

        [Theory]
        [InlineData(FormaDePagamento.Dinheiro)]
        [InlineData(FormaDePagamento.ValeAlimentacao)]
        [InlineData(FormaDePagamento.Debito)]
        public void TestQuantidadeGaranteCalculoNormal(FormaDePagamento formaDePagamento)
        {
            decimal quantidadeVendidaMenorQuePromocional = 5.5M;
            decimal valorUnitario = 10;
            decimal quantidadePromocionalMaiorQueComprado = 5.51M;
            decimal valorPromocional = 20M;
            decimal valorEsperado = 55M;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem();

            var valorCalculado = calculadoraPrecoVendaItem.Calcular(
                formaDePagamento, quantidadeVendidaMenorQuePromocional, valorUnitario,
                quantidadePromocionalMaiorQueComprado, valorPromocional);

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Theory]
        [InlineData(FormaDePagamento.Cheque, 55.2)]
        [InlineData(FormaDePagamento.Credito, 55.2)]
        [InlineData(FormaDePagamento.Dinheiro, 110.40)]
        [InlineData(FormaDePagamento.ValeAlimentacao, 110.40)]
        [InlineData(FormaDePagamento.Debito, 110.40)]
        public void TestFormaDePagamentoGaranteCalculoNormal(FormaDePagamento formaDePagamento,
            decimal valorEsperado)
        {
            decimal quantidadeVendidaMaiorQuePromocional = 5.52M;
            decimal valorUnitario = 10;
            decimal quantidadePromocionalMenorQueComprado = 5.51M;
            decimal valorPromocional = 20M;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem();

            var valorCalculado = calculadoraPrecoVendaItem.Calcular(
                formaDePagamento, quantidadeVendidaMaiorQuePromocional, valorUnitario,
                quantidadePromocionalMenorQueComprado, valorPromocional);

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Theory]
        [InlineData(FormaDePagamento.Dinheiro, 55.2)]
        [InlineData(FormaDePagamento.ValeAlimentacao, 55.2)]
        [InlineData(FormaDePagamento.Debito, 55.2)]
        [InlineData(FormaDePagamento.Credito, 110.4)]
        [InlineData(FormaDePagamento.Cheque, 110.4)]
        public void TestCalculaPrecoPromocional(FormaDePagamento formaDePagamento,
            decimal valorEsperado)
        {
            decimal quantidadeVendidaMaiorQuePromocional = 5.52M;
            decimal valorUnitario = 20;
            decimal quantidadePromocionalMenorQueComprado = 5.51M;
            decimal valorPromocional = 10;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem();

            var valorCalculado = calculadoraPrecoVendaItem.Calcular(
                formaDePagamento, quantidadeVendidaMaiorQuePromocional, valorUnitario,
                quantidadePromocionalMenorQueComprado, valorPromocional);

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Fact]
        public void TestQuantidadePromocionalMenorZeroSempreCalculoNormal()
        {
            decimal quantidadeVendidaMaiorQuePromocional = 5.52M;
            decimal valorUnitario = 10.5M;
            decimal quantidadePromocionalMenorZero = -0.01M;
            decimal valorPromocional = -1;
            decimal valorEsperado = 57.96M;
            var formaDePagamento = FormaDePagamento.Dinheiro;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem();

            var valorCalculado = calculadoraPrecoVendaItem.Calcular(
                formaDePagamento, quantidadeVendidaMaiorQuePromocional, valorUnitario,
                quantidadePromocionalMenorZero, valorPromocional);

            Assert.Equal(valorEsperado, valorCalculado);
        }
    }
}