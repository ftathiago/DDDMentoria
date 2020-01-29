using System.Collections.Generic;
using CrossCutting.Models;

namespace Dominio.Venda.DTO
{
    public class VendaDTO
    {
        public ClienteDTO Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public List<VendaItemDTO> Itens { get; set; }
    }
}