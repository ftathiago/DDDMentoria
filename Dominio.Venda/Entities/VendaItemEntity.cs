using Dominio.Venda.DTO;
using Dominio.Venda.ValueObjects;

namespace Dominio.Venda.Entity
{
    public class VendaItemEntity
    {
        public string Descricao { get; private set; }
        public ValorUnitario ValorUnitario { get; private set; }
        public ValorUnitario ValorUnitarioPromocional { get; private set; }

        public decimal Quantidade { get; private set; }
        public decimal QuantidadePromocional { get; private set; }

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
            return calculadoraPrecoVendaItem.Calcular(formaDePagamento, Quantidade, ValorUnitario,
               QuantidadePromocional, ValorUnitarioPromocional);
        }
    }
}