using System.Collections.Generic;

namespace Application.Venda.Models
{
    public class VendaModel
    {
        public ClienteModel Cliente { get; set; }
        public int FormaDePagamento { get; set; }
        public List<VendaItemModel> Itens { get; set; }
    }
}