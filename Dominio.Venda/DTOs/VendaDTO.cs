using System.Collections.Generic;

namespace Dominio.Venda.DTOs
{
    public class VendaDTO
    {
        public ClienteDTO? Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }

        public List<VendaItemDTO>? Itens { get; set; }
    }
}