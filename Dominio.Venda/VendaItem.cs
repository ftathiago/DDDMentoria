namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorUnitarioPromocional { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }

        private decimal quantidade;
        private decimal quantidadePromocional;

        public VendaItem(ProdutoVendido produtoVendido)
        {
            Descricao = produtoVendido.Descricao;
            ValorUnitario = produtoVendido.ValorUnitario;
            ValorUnitarioPromocional = produtoVendido.ValorUnitarioPromocional;
            quantidade = produtoVendido.QuantidadeComprada;
            quantidadePromocional = produtoVendido.QuantidadePromocional;
        }

        public decimal TotalItem()
        {
            if (TestarDeveUsarValorPromocional())
                return TotalItemPromocional();
            return TotalItemNormal();
        }

        public bool TestarDeveUsarValorPromocional()
        {
            var quantidadeEhPromocional = (quantidadePromocional > 0 && quantidade >= quantidadePromocional);
            var formasDePagamentoPromocionais = (
                this.FormaDePagamento == FormaDePagamento.Dinheiro
                || this.FormaDePagamento == FormaDePagamento.ValeAlimentacao
                );
            return quantidadeEhPromocional && formasDePagamentoPromocionais;
        }

        private decimal TotalItemPromocional()
        {
            return quantidade * ValorUnitarioPromocional;
        }

        private decimal TotalItemNormal()
        {
            return quantidade * ValorUnitario;
        }

        public void DefinirFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            FormaDePagamento = formaDePagamento;
        }
    }
}