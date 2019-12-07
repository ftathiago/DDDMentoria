namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem
    {
        private readonly FormaDePagamento formaDePagamento;
        public decimal QuantidadeVendida { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal QuantidadePromocional { get; set; }
        public decimal ValorPromocional { get; set; }
        public CalculadoraPrecoVendaItem(FormaDePagamento formaDePagamento)
        {
            this.formaDePagamento = formaDePagamento;
            ValorPromocional = 0;
            QuantidadeVendida = 0;
            ValorUnitario = 0;
            QuantidadePromocional = 0;
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
            var vendaNormalPelaQuantidade = (QuantidadeVendida < QuantidadePromocional) || QuantidadePromocional <= 0;

            return vendaNormalPelaQuantidade || formaDePagamentoNormal;
        }

        private decimal CalculoPrecoNormal()
        {
            return QuantidadeVendida * ValorUnitario;
        }

        private decimal CalcularPrecoPromocional()
        {
            return QuantidadeVendida * ValorPromocional;
        }
    }
}