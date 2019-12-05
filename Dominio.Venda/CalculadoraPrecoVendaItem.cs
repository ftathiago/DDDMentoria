namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem
    {
        private readonly decimal quantidadeVendida;
        private readonly decimal valorUnitario;
        private readonly decimal quantidadePromocional;
        private readonly FormaDePagamento formaDePagamento;
        private readonly decimal valorPromocional;
        public CalculadoraPrecoVendaItem(decimal quantidadeVendida, decimal valorUnitario,
            decimal quantidadePromocional, decimal valorPromocional,
            FormaDePagamento formaDePagamento)
        {
            this.quantidadeVendida = quantidadeVendida;
            this.valorUnitario = valorUnitario;
            this.quantidadePromocional = quantidadePromocional;
            this.formaDePagamento = formaDePagamento;
            this.valorPromocional = valorPromocional;
        }

        public decimal Calcular()
        {
            if (DeveUsarPrecoVendaNormal())
                return CalculoPrecoNormal();
            return CalcularPrecoPromocional();
        }

        private bool DeveUsarPrecoVendaNormal()
        {
            var formaDePagamentoNormal = (formaDePagamento == FormaDePagamento.Cheque || formaDePagamento == FormaDePagamento.Credito);
            var quantidadeVendidaNormal = quantidadeVendida < quantidadePromocional;

            return quantidadeVendidaNormal || formaDePagamentoNormal;
        }

        private decimal CalculoPrecoNormal()
        {
            return quantidadeVendida * valorUnitario;
        }

        private decimal CalcularPrecoPromocional()
        {
            return quantidadeVendida * valorPromocional;
        }
    }
}