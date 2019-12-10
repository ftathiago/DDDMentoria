namespace Dominio.Venda
{
    public interface ISalvarVendaService
    {
        string MensagemErro { get; }

        bool Executar();
    }
}