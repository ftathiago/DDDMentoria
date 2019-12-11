using Dominio.Venda.DTO;
using Dominio.Venda.Entities;

namespace Dominio.Venda
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaDTO vendaDTO);
    }
}