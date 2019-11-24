using System;
using Xunit;
using Dominio.Venda;

namespace Dominio.Venda.Test
{
    public class VendaTest
    {
        /* 
        Toda venda tem um cliente
        A venda, para ser válida, precisa possuir ao menos um produto
        Cada produto possui uma "Quantidade de promoção" que caso sejam vendidos produtos suficientes, será aplicado o valor promocional
        A venda só pode ser concluida após o pagamento ser aprovado
        A venda pode ter vários métodos de pagamento
        */
        [Fact]
        public void TestCriarVenda()
        {
            Venda venda = new Venda("Cliente");
            var cliente = venda.Cliente;
            Assert.Equal(cliente, "Cliente");
        }
    }
}
