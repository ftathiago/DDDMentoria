namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorUnitarioPromocional { get; private set; }

        private decimal quantidade;
        public VendaItem(ProdutoVendido produtoVendido)
        {
            Descricao = produtoVendido.Descricao;
            ValorUnitario = produtoVendido.ValorUnitario;
            ValorUnitarioPromocional = produtoVendido.ValorUnitarioPromocional;
            quantidade = produtoVendido.QuantidadeComprada;
        }

        public decimal TotalItem()
        {
            return ValorUnitario * quantidade;
        }
    }
}