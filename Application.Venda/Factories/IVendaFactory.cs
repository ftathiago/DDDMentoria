using CrossCutting.Models;
using Dominio.Venda.Entities;

namespace Application.Venda.Factories
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaDTO vendaDTO);
    }
}