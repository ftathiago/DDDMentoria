namespace Dominio.Venda
{
    public class VendaItem
    {
        public string Descricao { get; set; }
        public VendaItem(ProdutoVendido produtoVendido)
        {
            Descricao = produtoVendido.Descricao;
        }
    }
}