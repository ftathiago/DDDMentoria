using Dominio.Venda.ValueObjects;

namespace Dominio.Venda
{
    public interface ICalculadoraPrecoVendaItem
    {
        decimal Calcular(FormaDePagamento formaDePagamento, decimal quantidade, ValorUnitario valorUnitario,
            decimal quantidadePromocional = 0, ValorUnitario? valorPromocional = null);
    }
}