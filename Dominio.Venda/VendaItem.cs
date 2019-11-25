namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorUnitarioPromocional { get; private set; }

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
                return ValorUnitario * quantidade;
            return quantidade * ValorUnitarioPromocional;
        }
    }
}