namespace Dominio.Venda
{
    public class Cliente
    {
        public string Descricao { get; set; }
        public Cliente(string descricao)
        {
            this.Descricao = descricao;
        }
    }
}