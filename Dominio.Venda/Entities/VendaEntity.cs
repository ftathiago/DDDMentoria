using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Venda.DTOs;
using Dominio.Venda.Modules;

namespace Dominio.Venda.Entities
{
    public class VendaEntity
    {
        public ClienteDTO Cliente { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }
        public IEnumerable<VendaItemEntity> Itens { get => _itensLista; }
        private readonly IList<VendaItemEntity> _itensLista;
        protected VendaEntity()
        {
            _itensLista = new List<VendaItemEntity>();
            Cliente = new ClienteDTO(string.Empty);
            this.FormaDePagamento = FormaDePagamento.None;
        }
        public VendaEntity(ClienteDTO? cliente, FormaDePagamento formaDePagamento)
        {
            if (cliente == null)
                throw new ArgumentException("O cliente para esta venda não foi informado!");
            Cliente = cliente;
            _itensLista = new List<VendaItemEntity>();
            FormaDePagamento = formaDePagamento;
        }

        public void AdicionarVendaItem(VendaItemEntity vendaItem)
        {
            _itensLista.Add(vendaItem);
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