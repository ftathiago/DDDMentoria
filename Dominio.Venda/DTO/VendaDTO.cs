using System.Collections.Generic;

namespace Dominio.Venda.DTO
{
    public class VendaDTO
    {
        public Cliente Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }

        public List<VendaItemDTO> Itens { get; set; }
    }
}