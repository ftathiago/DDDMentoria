using System.Collections.Generic;
using CrossCutting.Interfaces;
using CrossCutting.Models;
using Dominio.Venda.Entities;

namespace Dominio.Venda.Services
{
    public interface ISalvarVendaService : IValidavel
    {
        bool Executar(VendaEntity venda);
    }
}