using Venda.Dominio.Repository;
using Venda.Dominio.Entities;
using System.Collections.Generic;
using Venda.Crosscutting.Models;

namespace Venda.Dominio.Services.Impl
{
    public class SalvarVendaService : ISalvarVendaService
    {

        private readonly IVendaRepository _vendaRepository;
        private readonly List<MensagemErro> _mensagensErro;

        public SalvarVendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
            _mensagensErro = new List<MensagemErro>();
        }

        public bool Executar(VendaEntity venda)
        {

            if (!venda.Validar())
            {
                _mensagensErro.Add(new MensagemErro("A venda está invalida!"));
                return false;
            }

            bool salvouVenda = _vendaRepository.Salvar(venda);
            if (!salvouVenda)
                _mensagensErro.Add(new MensagemErro("Não foi possível salvar a venda"));

            return salvouVenda;
        }

        public bool EhValido()
        {
            return _mensagensErro.Count == 0;
        }

        public IEnumerable<MensagemErro> PegarMensagensErro()
        {
            return _mensagensErro;
        }
    }
}