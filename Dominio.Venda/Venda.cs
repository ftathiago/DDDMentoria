namespace Dominio.Venda
{
    public class Venda
    {
        public string Cliente;

        public Venda(string cliente)
        {
            Cliente = cliente;
        }

        public void AdicionarProduto(string produto)
        {
            this.Produto = produto;
        }

        public bool Validar()
        {
            return !string.IsNullOrEmpty(Produto);
        }

        private string Produto;
    }
}