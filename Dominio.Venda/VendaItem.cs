namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorUnitarioPromocional { get; private set; }

        public decimal Quantidade { get; private set; }
        public decimal QuantidadePromocional { get; private set; }

        public VendaItem(ProdutoVendido produtoVendido)
        {
            Descricao = produtoVendido.Descricao;
            ValorUnitario = produtoVendido.ValorUnitario;
            ValorUnitarioPromocional = produtoVendido.ValorUnitarioPromocional;
            Quantidade = produtoVendido.QuantidadeComprada;
            QuantidadePromocional = produtoVendido.QuantidadePromocional;
        }
    }
}