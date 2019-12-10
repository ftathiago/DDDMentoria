using Xunit;
using Moq;

namespace Dominio.Venda.Test
{
    public class SalvarVendaServiceTest
    {
        [Fact]
        public void TestCriarServicoSalvarVenda()
        {
            var venda = new Venda("Cliente", FormaDePagamento.Dinheiro);
            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);

            Assert.NotNull(salvarVendaService);
        }

        [Fact]
        public void TestExecutarServicoComSucesso()
        {
            var vendaMock = new Mock<Venda>();
            vendaMock.SetReturnsDefault<bool>(true);
            Venda venda = vendaMock.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.True(executadoComSucesso);
        }

        [Fact]
        public void TestExecutarServicoSemSucesso()
        {
            var vendaMock = new Mock<Venda>();
            vendaMock.SetReturnsDefault<bool>(false);
            Venda venda = vendaMock.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.False(executadoComSucesso);
        }

        [Fact]
        public void TestExecutaComSucessoQuandoRepositorioEstaOK()
        {
            var mockVenda = new Mock<Venda>();
            mockVenda.SetReturnsDefault<bool>(true);
            Venda venda = mockVenda.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.True(executadoComSucesso);
        }
    }
}