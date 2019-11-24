namespace Dominio.Venda
{
    public class ProdutoVendido
    {
        public string Descricao { get; set; }
        public int QuantidadeComprada { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal QuantidadePromocional { get; set; }
        public decimal ValorUnitarioPromocional { get; set; }
    }
}