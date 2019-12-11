using Dominio.Venda.Entity;

namespace Dominio.Venda.Repository
{
    public interface IVendaRepository
    {
        bool Salvar(VendaEntity venda);
    }
}