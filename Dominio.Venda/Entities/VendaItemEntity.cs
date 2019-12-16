using CrossCutting.Models;
using Dominio.Venda.ValueObjects;
using Dominio.Venda.Modules;

namespace Dominio.Venda.Entities
{
    public class VendaItemEntity
    {
        public string Descricao { get; private set; }
        public ValorUnitario ValorUnitario { get; private set; }
        public ValorUnitario ValorUnitarioPromocional { get; private set; }

        public Quantidade Quantidade { get; private set; }
        public Quantidade QuantidadePromocional { get; private set; }

        private ICalculadoraPrecoVendaItem calculadoraPrecoVendaItem;

        public VendaItemEntity(VendaItemDTO vendaItemDTO, ICalculadoraPrecoVendaItem calculadoraPrecoVendaItem)
        {
            Descricao = vendaItemDTO.Descricao;
            ValorUnitario = vendaItemDTO.ValorUnitario;
            ValorUnitarioPromocional = vendaItemDTO.ValorUnitarioPromocional;
            Quantidade = vendaItemDTO.QuantidadeComprada;
            QuantidadePromocional = vendaItemDTO.QuantidadePromocional;
            this.calculadoraPrecoVendaItem = calculadoraPrecoVendaItem;
        }

        public decimal ValorTotal(FormaDePagamento formaDePagamento)
        {
            if (formaDePagamento == FormaDePagamento.None)
                return 0;
            return calculadoraPrecoVendaItem.Calcular(formaDePagamento, Quantidade, ValorUnitario,
               QuantidadePromocional, ValorUnitarioPromocional);
        }
    }
}