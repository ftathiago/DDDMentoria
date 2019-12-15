using System.Collections.Generic;
using CrossCutting.Interfaces;
using CrossCutting.Models;

namespace Application.Venda.App
{
    public interface IVendaApplication : IValidavel
    {
        bool ProcessarVenda(VendaDTO vendaDTO);
    }
}