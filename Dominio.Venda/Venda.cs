using System;

namespace Dominio.Venda
{
    public class Venda
    {
        public string Cliente;

        public Venda(string cliente)
        {
            Cliente = cliente;
        }

        public void AdicionarProduto(ProdutoVendido produto)
        {
            this.Produto = produto;
        }

        public bool Validar()
        {
            return Produto != null;
        }

        private ProdutoVendido Produto;

        public object TotalVenda()
        {
            return 4;
        }
    }
}