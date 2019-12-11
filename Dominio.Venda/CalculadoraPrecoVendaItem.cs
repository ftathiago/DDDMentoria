using System;
using Dominio.Venda.ValueObjects;

namespace Dominio.Venda
{
    public class CalculadoraPrecoVendaItem : ICalculadoraPrecoVendaItem
    {
        public CalculadoraPrecoVendaItem() { }

        public decimal Calcular(FormaDePagamento formaDePagamento, decimal quantidade, ValorUnitario valorUnitario,
            decimal quantidadePromocional = 0, ValorUnitario? valorPromocional = null)
        {
            if (DeveUsarPrecoVendaNormal(formaDePagamento, quantidade, quantidadePromocional))
                return CalculoPrecoNormal(quantidade, valorUnitario);
            return CalcularPrecoPromocional(quantidade, valorPromocional);
        }

        private bool DeveUsarPrecoVendaNormal(FormaDePagamento formaDePagamento,
            decimal quantidade, decimal quantidadePromocional)
        {
            if (!FormaDePagamentoEhValida(formaDePagamento))
                throw new ArgumentException("Forma de pagamento inválida!");

            var formaDePagamentoNormal = FormaDePagamentoDefineCalculoNormal(formaDePagamento);
            var vendaNormalPelaQuantidade = QuantidadeDefineCalculoNormal(quantidade, quantidadePromocional);

            return vendaNormalPelaQuantidade || formaDePagamentoNormal;
        }

        private bool FormaDePagamentoEhValida(FormaDePagamento formaDePagamento)
        {
            return formaDePagamento == FormaDePagamento.Dinheiro ||
                formaDePagamento == FormaDePagamento.ValeAlimentacao ||
                formaDePagamento == FormaDePagamento.Debito ||
                formaDePagamento == FormaDePagamento.Credito ||
                formaDePagamento == FormaDePagamento.Cheque;
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

        private decimal CalcularPrecoPromocional(decimal quantidade, ValorUnitario? valorPromocional)
        {
            if (valorPromocional == null)
                return 0;
            return quantidade * valorPromocional;
        }
    }
}