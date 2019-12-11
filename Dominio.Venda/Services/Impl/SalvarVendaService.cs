using Dominio.Venda.Repository;
using Dominio.Venda.Entities;

namespace Dominio.Venda.Services.Impl
{
    public class SalvarVendaService : ISalvarVendaService
    {
        public string MensagemErro { get; private set; }
        private readonly VendaEntity _venda;
        private readonly IVendaRepository _vendaRepository;
        public SalvarVendaService(VendaEntity venda, IVendaRepository vendaRepository)
        {
            this._venda = venda;
            this._vendaRepository = vendaRepository;
            this.MensagemErro = string.Empty;
        }

        public bool Executar()
        {
            if (!_venda.Validar())
            {
                MensagemErro = "A venda está invalida!";
                return false;
            }

            bool salvouVenda = _vendaRepository.Salvar(_venda);
            if (!salvouVenda)
                MensagemErro = "Não foi possível salvar a venda";

            return salvouVenda;
        }
    }
}