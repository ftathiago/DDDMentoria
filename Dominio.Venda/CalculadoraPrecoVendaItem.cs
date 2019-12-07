namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem
    {
        private FormaDePagamento FormaDePagamento { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal QuantidadePromocional { get; set; }
        public decimal ValorPromocional { get; set; }
        public CalculadoraPrecoVendaItem()
        {
            FormaDePagamento = FormaDePagamento.None;
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
            var formaDePagamentoNormal = FormaDePagamentoDefiniCalculoNormal();
            var vendaNormalPelaQuantidade = QuantidadeDefineCalculoNormal();

            return vendaNormalPelaQuantidade || formaDePagamentoNormal;
        }

        private bool FormaDePagamentoDefiniCalculoNormal()
        {
            if (FormaDePagamento == FormaDePagamento.Cheque)
                return true;
            if (FormaDePagamento == FormaDePagamento.Credito)
                return true;
            return false;
        }

        private bool QuantidadeDefineCalculoNormal()
        {
            if (QuantidadePromocional <= 0)
                return true;
            return (QuantidadeVendida < QuantidadePromocional);
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