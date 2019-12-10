using Dominio.Venda.DTO;

namespace Dominio.Venda
{
    public interface IVendaFactory
    {
        Venda Criar(VendaDTO vendaDTO);
    }
}