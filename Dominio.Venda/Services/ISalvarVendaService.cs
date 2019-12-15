using Dominio.Venda.Entities;

namespace Dominio.Venda.Services
{
    public interface ISalvarVendaService
    {
        string MensagemErro { get; }

        bool Executar(VendaEntity venda);
    }
}