using System.Collections.Generic;
using CrossCutting.Interfaces;
using CrossCutting.Models;
using Application.Venda.Models;

namespace Application.Venda.App
{
    public interface IVendaApplication : IValidavel
    {
        bool ProcessarVenda(VendaModel vendaModel);
    }
}