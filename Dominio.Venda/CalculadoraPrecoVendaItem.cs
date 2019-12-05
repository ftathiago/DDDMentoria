namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem
    {
        private readonly decimal quantidadeVendida;
        private readonly decimal valorUnitario;
        private readonly decimal quantidadePromocional;
        private readonly FormaDePagamento formaDePagamento;
        public CalculadoraPrecoVendaItem(decimal quantidadeVendida, decimal valorUnitario,
            decimal quantidadePromocional, decimal valorPromocional,
            FormaDePagamento formaDePagamento)
        {
            this.quantidadeVendida = quantidadeVendida;
            this.valorUnitario = valorUnitario;
            this.quantidadePromocional = quantidadePromocional;
            this.formaDePagamento = formaDePagamento;
        }

        public decimal Calcular()
        {
            var calculoNormal = quantidadeVendida * valorUnitario;
            if (formaDePagamento == FormaDePagamento.Cheque || formaDePagamento == FormaDePagamento.Credito)
                return calculoNormal;

            if (quantidadePromocional <= quantidadeVendida)
                return 0;
        }
    }
}