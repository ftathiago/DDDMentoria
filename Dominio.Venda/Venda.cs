using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Venda
{
    public class Venda
    {
        public Cliente Cliente { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }
        public IEnumerable<VendaItem> VendaItem { get => vendaItemLista; }
        private readonly IList<VendaItem> vendaItemLista;
        protected Venda()
        {
            vendaItemLista = new List<VendaItem>();
            this.FormaDePagamento = FormaDePagamento.None;
        }
        public Venda(Cliente cliente, FormaDePagamento formaDePagamento)
        {
            Cliente = cliente;
            vendaItemLista = new List<VendaItem>();
            FormaDePagamento = formaDePagamento;
        }

        public void AdicionarVendaItem(VendaItem vendaItem)
        {
            vendaItemLista.Add(vendaItem);
        }

        public virtual bool Validar()
        {
            if (FormaDePagamento == FormaDePagamento.None)
                return false;
            if (VendaItem.Count() <= 0)
                return false;
            if (TotalVenda() <= 0)
                return false;
            return true;
        }

        public decimal TotalVenda()
        {
            var totalVenda = VendaItem.Sum(p => p.ValorTotal(FormaDePagamento));
            return totalVenda;
        }
    }
}