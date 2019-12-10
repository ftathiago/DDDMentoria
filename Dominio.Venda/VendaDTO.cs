
using System.Collections.Generic;

namespace Dominio.Venda
{
    public class VendaDTO
    {
        public Cliente Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }

        public List<ProdutoVendido> Itens { get; set; }
    }
}