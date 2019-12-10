namespace Dominio.Venda
{
    public class SalvarVendaService : ISalvarVendaService
    {
        private readonly Venda venda;
        public SalvarVendaService(Venda venda)
        {
            this.venda = venda;
        }

        public bool Executar()
        {
            if (!venda.Validar())
                return false;
            return true;
        }
    }
}