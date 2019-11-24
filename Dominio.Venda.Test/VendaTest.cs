using System;
using Xunit;
using Dominio.Venda;

namespace Dominio.Venda.Test
{
    public class VendaTest
    {
        /* 
        Toda compra tem um cliente
        Cada produto possui uma "Quantidade de promoção" que caso sejam comprados produtos suficientes, será aplicado o valor promocional
        A compra só pode ser concluida após o pagamento ser aprovado
        A compra pode ter vários métodos de pagamento
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
