using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Venda
{
    public class Venda
    {
        public string Cliente;
        private readonly ICollection<VendaItem> VendaItem;

        public FormaDePagamento FormaDePagamento { get; private set; }

        public Venda(string cliente, FormaDePagamento formaDePagamento)
        {
            Cliente = cliente;
            VendaItem = new List<VendaItem>();
            FormaDePagamento = formaDePagamento;
        }

        public void AdicionarVendaItem(VendaItem vendaItem)
        {
            vendaItem.DefinirFormaDePagamento(FormaDePagamento);
            VendaItem.Add(vendaItem);

        }

        public bool Validar()
        {
            if (FormaDePagamento == FormaDePagamento.None)
                return false;
            if (VendaItem.Count <= 0)
                return false;
            if (TotalVenda() <= 0)
                return false;
            return true;
        }

        public decimal TotalVenda()
        {
            var calculadora = new CalculadoraPrecoVendaItem(FormaDePagamento);
            var totalVenda = VendaItem.Sum(p =>
            {
                calculadora.QuantidadeVendida = p.Quantidade;
                calculadora.QuantidadePromocional = p.QuantidadePromocional;
                calculadora.ValorPromocional = p.ValorUnitarioPromocional;
                calculadora.ValorUnitario = p.ValorUnitario;
                return calculadora.Calcular();
            });
            return totalVenda;
        }
    }
}