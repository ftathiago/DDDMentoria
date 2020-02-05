using Venda.Dominio.ValueObjects;
using Venda.Dominio.DTO;


namespace Venda.Dominio.Modules
{
    public interface ICalculadoraPrecoVendaItem
    {
        ValorUnitario Calcular(FormaDePagamento formaDePagamento, Quantidade quantidade, ValorUnitario valorUnitario,
            Quantidade? quantidadePromocional = null, ValorUnitario? valorPromocional = null);
    }
}