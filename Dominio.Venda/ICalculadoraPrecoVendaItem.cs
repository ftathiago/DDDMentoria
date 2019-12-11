using Dominio.Venda.ValueObjects;

namespace Dominio.Venda
{
    public interface ICalculadoraPrecoVendaItem
    {
        ValorUnitario Calcular(FormaDePagamento formaDePagamento, Quantidade quantidade, ValorUnitario valorUnitario,
            Quantidade? quantidadePromocional = null, ValorUnitario? valorPromocional = null);
    }
}