using CrossCutting.Models;
using Dominio.Venda.Entities;

namespace Dominio.Venda.Factories
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaDTO vendaDTO);
    }
}