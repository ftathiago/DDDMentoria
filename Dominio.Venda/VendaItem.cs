using Dominio.Venda.DTO;

namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorUnitarioPromocional { get; private set; }

        public decimal Quantidade { get; private set; }
        public decimal QuantidadePromocional { get; private set; }

        private ICalculadoraPrecoVendaItem calculadoraPrecoVendaItem;

        public VendaItem(VendaItemDTO vendaItemDTO, ICalculadoraPrecoVendaItem calculadoraPrecoVendaItem)
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