namespace Dominio.Venda
{
    public class ProdutoVendido
    {
        public string Descricao { get; set; }
        public int QuantidadeComprada { get; set; }
        public int ValorUnitario { get; set; }
        public decimal QuantidadePromocional { get; set; }
        public decimal ValorUnitarioPromocional { get; set; }
    }
}