namespace Dominio.Venda
{
    public interface ICalculadoraPrecoVendaItem
    {
        FormaDePagamento FormaDePagamento { get; set; }
        decimal QuantidadeVendida { get; set; }
        decimal ValorUnitario { get; set; }
        decimal QuantidadePromocional { get; set; }
        decimal ValorPromocional { get; set; }
        decimal Calcular();
    }
}