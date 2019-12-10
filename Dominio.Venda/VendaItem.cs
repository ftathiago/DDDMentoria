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

        public VendaItem(ProdutoVendido produtoVendido, ICalculadoraPrecoVendaItem calculadoraPrecoVendaItem)
        {
            Descricao = produtoVendido.Descricao;
            ValorUnitario = produtoVendido.ValorUnitario;
            ValorUnitarioPromocional = produtoVendido.ValorUnitarioPromocional;
            Quantidade = produtoVendido.QuantidadeComprada;
            QuantidadePromocional = produtoVendido.QuantidadePromocional;
            this.calculadoraPrecoVendaItem = calculadoraPrecoVendaItem;
        }

        public decimal ValorTotal(FormaDePagamento formaDePagamento)
        {
            return calculadoraPrecoVendaItem.Calcular(formaDePagamento, Quantidade, ValorUnitario,
               QuantidadePromocional, ValorUnitarioPromocional);
        }
    }
}