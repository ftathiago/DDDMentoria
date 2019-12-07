using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Venda
{
    public class Venda
    {
        public string Cliente;
        public FormaDePagamento FormaDePagamento { get; private set; }
        private readonly ICollection<VendaItem> VendaItem;
        private readonly CalculadoraPrecoVendaItem calculadoraPrecoVenda;
        public Venda(string cliente, FormaDePagamento formaDePagamento, CalculadoraPrecoVendaItem calculadoraPrecoVendaItem)
        {
            Cliente = cliente;
            VendaItem = new List<VendaItem>();
            FormaDePagamento = formaDePagamento;
            calculadoraPrecoVenda = calculadoraPrecoVendaItem;
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
            var totalVenda = VendaItem.Sum(p =>
            {
                calculadoraPrecoVenda.QuantidadeVendida = p.Quantidade;
                calculadoraPrecoVenda.QuantidadePromocional = p.QuantidadePromocional;
                calculadoraPrecoVenda.ValorPromocional = p.ValorUnitarioPromocional;
                calculadoraPrecoVenda.ValorUnitario = p.ValorUnitario;
                return calculadoraPrecoVenda.Calcular();
            });
            return totalVenda;
        }
    }
}