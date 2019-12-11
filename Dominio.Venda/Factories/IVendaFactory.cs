using Dominio.Venda.DTO;
using Dominio.Venda.Entity;

namespace Dominio.Venda
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaDTO vendaDTO);
    }
}