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
            VendaItem.Add(vendaItem);
        }

        public bool Validar()
        {
            return VendaItem.Count > 0 && TotalVenda() > 0;
        }

        public decimal TotalVenda()
        {
            /*
                Percebo um problema aqui. Toda vez que eu invocar esse metódo o array será varrido.
                Caso o array seja muito grande, a performance pode ser impactada. Pensei, então, em
                Escrever alguma espécie de "cache", em uma classe, para evitar o recálculo.
                Mas não sei se o DDD ou a experiência me levaram a isso. Ou ainda, se estou pensando muito à frente
                Fugindo dos baby steps.
            */
            var totalVenda = VendaItem.Sum(p => p.TotalItem());
            return totalVenda;
        }
    }
}