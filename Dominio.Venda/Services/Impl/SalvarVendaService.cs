using Dominio.Venda.Repository;
using Dominio.Venda.Entity;

namespace Dominio.Venda.Services.Impl
{
    public class SalvarVendaService : ISalvarVendaService
    {
        public string MensagemErro { get; private set; }
        private readonly VendaEntity venda;
        private readonly IVendaRepository vendaRepository;
        public SalvarVendaService(VendaEntity venda, IVendaRepository vendaRepository)
        {
            this.venda = venda;
            this.vendaRepository = vendaRepository;
            this.MensagemErro = string.Empty;
        }

        public bool Executar()
        {
            if (!venda.Validar())
            {
                MensagemErro = "A venda está invalida!";
                return false;
            }

            bool salvouVenda = vendaRepository.Salvar(venda);
            if (!salvouVenda)
                MensagemErro = "Não foi possível salvar a venda";

            return salvouVenda;
        }
    }
}