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

            return CalculoPrecoNormal();
        }

        private decimal CalculoPrecoNormal()
        {
            var formaDePagamentoNormal = (formaDePagamento == FormaDePagamento.Cheque || formaDePagamento == FormaDePagamento.Credito);
            var quantidadeAbaixoDoPromocional = quantidadeVendida >= quantidadePromocional;
            var calculoNormal = quantidadeVendida * valorUnitario;
            if ((!quantidadeAbaixoDoPromocional) || formaDePagamentoNormal)
                return calculoNormal;
            return 0;
        }
    }
}