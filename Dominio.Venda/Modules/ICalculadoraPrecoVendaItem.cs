using Dominio.Venda.ValueObjects;
using CrossCutting.Models;

namespace Dominio.Venda.Modules
{
    public interface ICalculadoraPrecoVendaItem
    {
        ValorUnitario Calcular(FormaDePagamento formaDePagamento, Quantidade quantidade, ValorUnitario valorUnitario,
            Quantidade? quantidadePromocional = null, ValorUnitario? valorPromocional = null);
    }
}