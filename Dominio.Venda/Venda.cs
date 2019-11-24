using System;
using System.Collections.Generic;

namespace Dominio.Venda
{
    public class Venda
    {
        public string Cliente;
        private readonly ICollection<ProdutoVendido> Produto;

        public Venda(string cliente)
        {
            Cliente = cliente;
            Produto = new List<ProdutoVendido>();
        }

        public void AdicionarProduto(ProdutoVendido produtoVendido)
        {
            Produto.Add(produtoVendido);
        }

        public bool Validar()
        {
            return Produto != null;
        }

        public object TotalVenda()
        {
            return 4;
        }
    }
}