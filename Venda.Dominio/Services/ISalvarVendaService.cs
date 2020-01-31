using System.Collections.Generic;
using Venda.Crosscutting.Interfaces;
using Venda.Crosscutting.Models;
using Venda.Dominio.Entities;

namespace Venda.Dominio.Services
{
    public interface ISalvarVendaService : IValidavel
    {
        bool Executar(VendaEntity venda);
    }
}