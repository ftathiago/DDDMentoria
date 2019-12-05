using Xunit;

namespace Dominio.Venda.Test
{
    public class CalculadoraPrecoVendaItemTest
    {
        [Fact]
        public void TestCriarCalculadora()
        {
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem(
                quantidadeVendida: 1.5M,
                valorUnitario: 1.5M,
                quantidadePromocional: 1.5M,
                valorPromocional: 1.5M,
                formaDePagamento: FormaDePagamento.None);

            Assert.NotNull(calculadoraPrecoVendaItem);
        }

        [Fact]
        public void TestQuantidadeGaranteCalculoNormal()
        {
            FormaDePagamento formaDePagamento = FormaDePagamento.Dinheiro;
            decimal quantidadeVendidaMenorQuePromocional = 5.5M;
            decimal valorUnitario = 10;
            decimal quantidadePromocionalMaiorQueComprado = 5.51M;
            decimal valorPromocional = 20M;
            decimal valorEsperado = 55M;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem(
                 quantidadeVendida: quantidadeVendidaMenorQuePromocional,
                 valorUnitario: valorUnitario,
                 quantidadePromocional: quantidadePromocionalMaiorQueComprado,
                 valorPromocional: valorPromocional,
                 formaDePagamento: formaDePagamento);

            var valorCalculado = calculadoraPrecoVendaItem.Calcular();

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Theory]
        [InlineData(FormaDePagamento.Cheque)]
        [InlineData(FormaDePagamento.Credito)]
        public void TestFormaDePagamentoGaranteCalculoNormal(FormaDePagamento formaDePagamento)
        {
            decimal quantidadeVendidaMaiorQuePromocional = 5.52M;
            decimal valorUnitario = 10;
            decimal quantidadePromocionalMenorQueComprado = 5.51M;
            decimal valorPromocional = 20M;
            decimal valorEsperado = 55.2M;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem(
                 quantidadeVendida: quantidadeVendidaMaiorQuePromocional,
                 valorUnitario: valorUnitario,
                 quantidadePromocional: quantidadePromocionalMenorQueComprado,
                 valorPromocional: valorPromocional,
                 formaDePagamento: formaDePagamento);

            var valorCalculado = calculadoraPrecoVendaItem.Calcular();

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Theory]
        [InlineData(FormaDePagamento.Dinheiro)]
        [InlineData(FormaDePagamento.ValeAlimentacao)]
        [InlineData(FormaDePagamento.Debito)]
        public void TestCalculaPrecoPromocional(FormaDePagamento formaDePagamento)
        {
            decimal quantidadeVendidaMaiorQuePromocional = 5.52M;
            decimal valorUnitario = 20;
            decimal quantidadePromocionalMenorQueComprado = 5.51M;
            decimal valorPromocional = 10;
            decimal valorEsperado = 55.2M;
            var calculadoraPrecoVendaItem = new CalculadoraPrecoVendaItem(
                 quantidadeVendida: quantidadeVendidaMaiorQuePromocional,
                 valorUnitario: valorUnitario,
                 quantidadePromocional: quantidadePromocionalMenorQueComprado,
                 valorPromocional: valorPromocional,
                 formaDePagamento: formaDePagamento);

            var valorCalculado = calculadoraPrecoVendaItem.Calcular();

            Assert.Equal(valorEsperado, valorCalculado);
        }


    }
}