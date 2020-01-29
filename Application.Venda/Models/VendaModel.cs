using System.Collections.Generic;
using CrossCutting.Models;

namespace Application.Venda.Models
{
    public class VendaModel
    {
        public ClienteModel Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public List<VendaItemModel> Itens { get; set; }
    }
}