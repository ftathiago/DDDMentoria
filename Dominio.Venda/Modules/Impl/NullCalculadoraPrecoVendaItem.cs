using CrossCutting.Models;
using Dominio.Venda.ValueObjects;
using Dominio.Venda.DTO;

namespace Dominio.Venda.Modules.Impl
{
    public class NullCalculadoraPrecoVendaItem : ICalculadoraPrecoVendaItem
    {
        public ValorUnitario Calcular(FormaDePagamento formaDePagamento, Quantidade quantidade, ValorUnitario valorUnitario, Quantidade? quantidadePromocional = null, ValorUnitario? valorPromocional = null)
        {
            return 0;
        }
    }
}