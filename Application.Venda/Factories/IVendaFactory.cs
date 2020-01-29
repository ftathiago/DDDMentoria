using Dominio.Venda.Entities;
using Application.Venda.Models;

namespace Application.Venda.Factories
{
    public interface IVendaFactory
    {
        VendaEntity Criar(VendaModel vendaDTO);
    }
}