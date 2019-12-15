using CrossCutting.Models;
using Dominio.Venda.Entities;
using Dominio.Venda.Services;
using Application.Venda.Factories;

namespace Application.Venda.App.Impl
{
    public class VendaApplication : IVendaApplication
    {
        private readonly IVendaFactory _vendaFactory;
        private readonly ISalvarVendaService _salvarVendaService;

        public VendaApplication(IVendaFactory vendaFactory, ISalvarVendaService salvarVendaService)
        {
            _vendaFactory = vendaFactory;
            _salvarVendaService = salvarVendaService;
        }

        public bool ProcessarVenda(VendaDTO vendaDTO)
        {
            VendaEntity venda = _vendaFactory.Criar(vendaDTO);

            _salvarVendaService.Executar();

            return true;
        }
    }
}