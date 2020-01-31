using Venda.Crosscutting.Models;
using Venda.Dominio.Entities;
using Venda.Dominio.Services;
using Venda.Application.Factories;
using Venda.Application.Models;
using System.Collections.Generic;

namespace Venda.Application.App.Impl
{
    public class VendaApplication : IVendaApplication
    {
        private readonly IVendaEntityFactory _vendaFactory;
        private readonly ISalvarVendaService _salvarVendaService;
        private readonly List<MensagemErro> _mensagensErro;

        public VendaApplication(IVendaEntityFactory vendaFactory, ISalvarVendaService salvarVendaService)
        {
            _vendaFactory = vendaFactory;
            _salvarVendaService = salvarVendaService;
            _mensagensErro = new List<MensagemErro>();
        }

        public bool ProcessarVenda(VendaModel vendaModel)
        {
            VendaEntity venda = _vendaFactory.Criar(vendaModel);

            var executouComSucesso = _salvarVendaService.Executar(venda);
            if (!executouComSucesso)
            {
                CapturarErros();
            }
            return executouComSucesso;
        }

        public IEnumerable<MensagemErro> PegarMensagensErro()
        {
            foreach (var mensagem in _mensagensErro)
            {
                yield return mensagem;
            }
        }

        public bool EhValido()
        {
            return _mensagensErro.Count == 0;
        }

        private void CapturarErros()
        {
            _mensagensErro.Clear();
            foreach (var mensagemErro in _salvarVendaService.PegarMensagensErro())
            {
                _mensagensErro.Add(mensagemErro);
            }
        }
    }
}