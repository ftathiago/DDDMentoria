using Dominio.Venda.DTOs;
using Dominio.Venda.Entities;

namespace Dominio.Venda
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaDTO vendaDTO);
    }
}