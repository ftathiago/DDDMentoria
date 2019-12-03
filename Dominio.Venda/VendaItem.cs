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
            if (quantidadePromocional < 0 || quantidade < quantidadePromocional)
                return TotalItemNormal();

            return TotalItemPromocional();
        }

        public bool TestarDeveUsarValorPromocional()
        {
            return false;
        }

        private decimal TotalItemPromocional()
        {
            return quantidade * ValorUnitarioPromocional;
        }

        private decimal TotalItemNormal()
        {
            return 0M;
        }

        public void DefinirFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            FormaDePagamento = formaDePagamento;
        }
    }
}