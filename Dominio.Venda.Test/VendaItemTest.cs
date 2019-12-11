using Dominio.Venda.DTO;
using Dominio.Venda.Entity;
using Xunit;
using Moq;

namespace Dominio.Venda.Test
{
    public class VendaItemTest
    {
        [Fact]
        public void TestCriarVendaItem()
        {
            VendaItemDTO vendaItemDTO = ProdutoVendidoFactory("Produto", 1, 10);

            VendaItemEntity vendaItem = new VendaItemEntity(vendaItemDTO, new CalculadoraPrecoVendaItem());

            Assert.NotNull(vendaItem);
        }

        [Fact]
        public void TestVendaItemExpoeValorUnitarioNormal()
        {
            decimal valorEsperado = 10.5M;
            VendaItemDTO vendaItemDTO = ProdutoVendidoFactory(
                descricao: "Produto",
                quantidadeComprada: 1,
                valorUnitario: valorEsperado);
            VendaItemEntity vendaItem = new VendaItemEntity(vendaItemDTO, new CalculadoraPrecoVendaItem());

            decimal valorExposto = vendaItem.ValorUnitario;

            Assert.Equal(valorEsperado, valorExposto);
        }

        [Fact]
        public void TestVendaItemExpoeValorPromocional()
        {
            decimal valorEsperado = 10.5M;
            VendaItemDTO vendaItemDTO = ProdutoVendidoFactory(
                descricao: "Produto",
                quantidadeComprada: 1,
                valorUnitario: 0,
                valorUnitarioPromocional: valorEsperado);
            VendaItemEntity vendaItem = new VendaItemEntity(vendaItemDTO, new CalculadoraPrecoVendaItem());

            decimal valorEsposto = vendaItem.ValorUnitarioPromocional;

            Assert.Equal(valorEsperado, valorEsposto);
        }

        [Fact]
        public void TestVendaItemCalculaValorTotalUsandoCalculadora()
        {
            decimal valorEsperado = 10.5M;
            var mock = new Mock<ICalculadoraPrecoVendaItem>();
            mock.Setup(library => library.Calcular(It.IsAny<FormaDePagamento>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(valorEsperado);
            ICalculadoraPrecoVendaItem calculadora = mock.Object;
            VendaItemDTO vendaItemDTO = ProdutoVendidoFactory(
                descricao: "Produto",
                quantidadeComprada: 1,
                valorUnitario: 0,
                valorUnitarioPromocional: valorEsperado);
            VendaItemEntity vendaItem = new VendaItemEntity(vendaItemDTO, calculadora);

            decimal valorEsposto = vendaItem.ValorTotal(FormaDePagamento.Dinheiro);

            Assert.Equal(valorEsperado, valorEsposto);
        }



        private VendaItemDTO ProdutoVendidoFactory(string descricao, decimal quantidadeComprada, decimal valorUnitario, decimal quantidadePromocional = -1, decimal valorUnitarioPromocional = -1)
        {
            return new VendaItemDTO
            {
                Descricao = descricao,
                QuantidadeComprada = quantidadeComprada,
                ValorUnitario = valorUnitario,
                QuantidadePromocional = quantidadePromocional,
                ValorUnitarioPromocional = valorUnitarioPromocional
            };
        }
    }
}