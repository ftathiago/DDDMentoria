namespace Dominio.Venda
{
    public class SalvarVendaService : ISalvarVendaService
    {
        private readonly Venda venda;
        private readonly IVendaRepository vendaRepository;
        public SalvarVendaService(Venda venda, IVendaRepository vendaRepository)
        {
            this.venda = venda;
            this.vendaRepository = vendaRepository;
        }

        public bool Executar()
        {
            if (!venda.Validar())
                return false;

            return vendaRepository.Salvar(venda);
        }
    }
}