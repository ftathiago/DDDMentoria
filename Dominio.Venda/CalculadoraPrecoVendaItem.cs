namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem
    {
        private readonly decimal quantidadeVendida;
        private readonly decimal valorUnitario;
        public CalculadoraPrecoVendaItem(decimal quantidadeVendida, decimal valorUnitario,
            decimal quantidadePromocional, decimal valorPromocional,
            FormaDePagamento formaDePagamento)
        {
            this.quantidadeVendida = quantidadeVendida;
            this.valorUnitario = valorUnitario;
        }

        public decimal Calcular()
        {
            return quantidadeVendida * valorUnitario;
        }
    }
}