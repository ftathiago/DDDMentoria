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
            return Produto.Count > 0 && TotalVenda() > 0;
        }

        public decimal TotalVenda()
        {
            /*
                Percebo um problema aqui. Toda vez que eu invocar esse metódo o array será varrido.
                Caso o array seja muito grande, a performance pode ser impactada. Pensei, então, em
                Escrever alguma espécie de "cache", em uma classe, para evitar o recálculo.
                Mas não sei se o DDD ou a experiência me levaram a isso. Ou ainda, se estou pensando muito à frente
                Fugindo dos baby steps.
            */
            var totalVenda = Produto.Sum(p =>
            {
                if (p.QuantidadePromocional > -1 && p.QuantidadeComprada >= p.QuantidadePromocional)
                    return p.QuantidadeComprada * p.ValorUnitarioPromocional;
                return p.QuantidadeComprada * p.ValorUnitario;
            });
            return totalVenda;
        }
    }
}