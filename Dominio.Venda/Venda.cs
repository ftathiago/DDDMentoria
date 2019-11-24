using System;
using System.Collections.Generic;
using System.Linq;

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
            return Produto.Count > 0;
        }

        public object TotalVenda()
        {
            var totalVenda = Produto.Sum(p => p.QuantidadeComprada * p.ValorUnitario);
            return totalVenda;
        }
    }
}