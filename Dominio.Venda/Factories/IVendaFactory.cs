using Dominio.Venda.DTOs;
using Dominio.Venda.Entities;

namespace Dominio.Venda.Factories
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaDTO vendaDTO);
    }
}