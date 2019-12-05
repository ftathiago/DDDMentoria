namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem
    {
        private readonly decimal quantidadeVendida;
        private readonly decimal valorUnitario;
        private readonly decimal quantidadePromocional;
        public CalculadoraPrecoVendaItem(decimal quantidadeVendida, decimal valorUnitario,
            decimal quantidadePromocional, decimal valorPromocional,
            FormaDePagamento formaDePagamento)
        {
            this.quantidadeVendida = quantidadeVendida;
            this.valorUnitario = valorUnitario;
            this.quantidadePromocional = quantidadePromocional;
        }

        public decimal Calcular()
        {
            if (quantidadePromocional <= quantidadeVendida)
                return 0;
            return quantidadeVendida * valorUnitario;
        }
    }
}