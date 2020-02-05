using System.Collections.Generic;

namespace Venda.Dominio.DTO
{
    public class VendaDTO
    {
        public VendaDTO()
        {
            Cliente = new ClienteDTO(int.MinValue);
            Itens = new List<VendaItemDTO>();
        }
        public ClienteDTO Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public List<VendaItemDTO> Itens { get; set; }
    }
}