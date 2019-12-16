using System.Collections.Generic;

namespace CrossCutting.Models
{
    public class VendaDTO
    {
        public ClienteDTO Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public List<VendaItemDTO> Itens { get; set; }
    }
}