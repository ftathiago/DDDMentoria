namespace Dominio.Venda
{
    public class SalvarVendaService : ISalvarVendaService
    {
        public string MensagemErro { get; private set; }
        private readonly Venda venda;
        private readonly IVendaRepository vendaRepository;
        public SalvarVendaService(Venda venda, IVendaRepository vendaRepository)
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

            MensagemErro = "Não foi possível salvar a venda";

            return vendaRepository.Salvar(venda);
        }
    }
}