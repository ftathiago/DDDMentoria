namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem : ICalculadoraPrecoVendaItem
    {
        public CalculadoraPrecoVendaItem() { }

        public decimal Calcular(FormaDePagamento formaDePagamento, decimal quantidade, decimal valorUnitario,
            decimal quantidadePromocional = 0, decimal valorPromocional = 0)
        {
            if (DeveUsarPrecoVendaNormal(formaDePagamento, quantidade, quantidadePromocional))
                return CalculoPrecoNormal(quantidade, valorUnitario);
            return CalcularPrecoPromocional(quantidade, valorPromocional);
        }

        private bool DeveUsarPrecoVendaNormal(FormaDePagamento formaDePagamento,
            decimal quantidade, decimal quantidadePromocional)
        {
            var formaDePagamentoNormal = FormaDePagamentoDefineCalculoNormal(formaDePagamento);
            var vendaNormalPelaQuantidade = QuantidadeDefineCalculoNormal(quantidade, quantidadePromocional);

            return vendaNormalPelaQuantidade || formaDePagamentoNormal;
        }

        private bool FormaDePagamentoDefineCalculoNormal(FormaDePagamento formaDePagamento)
        {
            if (formaDePagamento == FormaDePagamento.Cheque)
                return true;
            if (formaDePagamento == FormaDePagamento.Credito)
                return true;
            return false;
        }

        private bool QuantidadeDefineCalculoNormal(decimal quantidade, decimal quantidadePromocional)
        {
            if (quantidadePromocional <= 0)
                return true;
            return (quantidade < quantidadePromocional);
        }

        private decimal CalculoPrecoNormal(decimal quantidade, decimal valorUnitario)
        {
            return quantidade * valorUnitario;
        }

        private decimal CalcularPrecoPromocional(decimal quantidade, decimal valorPromocional)
        {
            return quantidade * valorPromocional;
        }
    }
}