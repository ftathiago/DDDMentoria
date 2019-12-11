using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Venda.DTOs;

namespace Dominio.Venda.Entities
{
    public class VendaEntity
    {
        public ClienteDTO Cliente { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }
        public IEnumerable<VendaItemEntity> Itens { get => itensLista; }
        private readonly IList<VendaItemEntity> itensLista;
        protected VendaEntity()
        {
            itensLista = new List<VendaItemEntity>();
            Cliente = new ClienteDTO(string.Empty);
            this.FormaDePagamento = FormaDePagamento.None;
        }
        public VendaEntity(ClienteDTO cliente, FormaDePagamento formaDePagamento)
        {
            Cliente = cliente;
            itensLista = new List<VendaItemEntity>();
            FormaDePagamento = formaDePagamento;
        }

        public void AdicionarVendaItem(VendaItemEntity vendaItem)
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