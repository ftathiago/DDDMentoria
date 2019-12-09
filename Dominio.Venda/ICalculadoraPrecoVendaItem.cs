namespace Dominio.Venda
{
    public interface ICalculadoraPrecoVendaItem
    {
        decimal Calcular(FormaDePagamento formaDePagamento, decimal quantidade, decimal valorUnitario,
            decimal quantidadePromocional = 0, decimal valorPromocional = 0);
    }
}