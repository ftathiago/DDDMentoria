using Dominio.Venda.Entities;
using Application.Venda.Models;

namespace Application.Venda.Factories
{
    public interface IVendaEntityFactory
    {
        VendaEntity Criar(VendaModel vendaDTO);
    }
}