namespace Dominio.Venda
{
    public interface IVendaFactory
    {
        Venda Criar(VendaDTO vendaDTO);
    }
}