namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorUnitarioPromocional { get; private set; }

        public decimal Quantidade { get; private set; }
        public decimal QuantidadePromocional { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }

        public VendaItem(ProdutoVendido produtoVendido)
        {
            Descricao = produtoVendido.Descricao;
            ValorUnitario = produtoVendido.ValorUnitario;
            ValorUnitarioPromocional = produtoVendido.ValorUnitarioPromocional;
            Quantidade = produtoVendido.QuantidadeComprada;
            QuantidadePromocional = produtoVendido.QuantidadePromocional;
        }

        public decimal TotalItem()
        {
            if (TestarDeveUsarValorPromocional())
                return TotalItemPromocional();
            return TotalItemNormal();
        }

        public bool TestarDeveUsarValorPromocional()
        {
            var quantidadeEhPromocional = (QuantidadePromocional > 0 && Quantidade >= QuantidadePromocional);
            var formasDePagamentoPromocionais = (
                this.FormaDePagamento == FormaDePagamento.Dinheiro
                || this.FormaDePagamento == FormaDePagamento.ValeAlimentacao
                || this.FormaDePagamento == FormaDePagamento.Debito);
            return quantidadeEhPromocional && formasDePagamentoPromocionais;
        }

        private decimal TotalItemPromocional()
        {
            return Quantidade * ValorUnitarioPromocional;
        }

        private decimal TotalItemNormal()
        {
            return Quantidade * ValorUnitario;
        }

        public void DefinirFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            FormaDePagamento = formaDePagamento;
        }
    }
}