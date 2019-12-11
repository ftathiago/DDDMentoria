using Dominio.Venda.Entities;

namespace Dominio.Venda.Repository
{
    public interface IVendaRepository
    {
        bool Salvar(VendaEntity venda);
    }
}