using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Venda
{
    public class Venda
    {
        public Cliente Cliente { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }
        public IEnumerable<VendaItem> Itens { get => itensLista; }
        private readonly IList<VendaItem> itensLista;
        protected Venda()
        {
            itensLista = new List<VendaItem>();
            this.FormaDePagamento = FormaDePagamento.None;
        }
        public Venda(Cliente cliente, FormaDePagamento formaDePagamento)
        {
            Cliente = cliente;
            itensLista = new List<VendaItem>();
            FormaDePagamento = formaDePagamento;
        }

        public void AdicionarVendaItem(VendaItem vendaItem)
        {
            itensLista.Add(vendaItem);
        }

        public virtual bool Validar()
        {
            if (FormaDePagamento == FormaDePagamento.None)
                return false;
            if (Itens.Count() <= 0)
                return false;
            if (TotalVenda() <= 0)
                return false;
            return true;
        }

        public decimal TotalVenda()
        {
            var totalVenda = Itens.Sum(p => p.ValorTotal(FormaDePagamento));
            return totalVenda;
        }
    }
}