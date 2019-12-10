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
            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda);

            Assert.NotNull(salvarVendaService);
        }

        [Fact]
        public void TestExecutarServicoComSucesso()
        {
            var mock = new Mock<Venda>();
            mock
                .Setup(v => v.Validar())
                .Returns(true);
            Venda venda = mock.Object;
            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda);

            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.True(executadoComSucesso);
        }

        [Fact]
        public void TestExecutarServicoSemSucesso()
        {
            var mock = new Mock<Venda>();
            mock
                .Setup(v => v.Validar())
                .Returns(false);
            Venda venda = mock.Object;
            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda);

            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.False(executadoComSucesso);
        }

        [Fact]
        public void TestExecutaComSucessoQuandoRepositorioEstaOK()
        {
            var mockVenda = new Mock<Venda>();
            mockVenda
                .Setup(v => v.Validar())
                .Returns(false);
            Venda venda = mockVenda.Object;
            var mockVendaRepository = new Mock<IVendaRepository>();
            mockVendaRepository
                .Setup(vr => vr.Salvar(It.IsAny<Venda>()))
                .Returns(true);
            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda);

            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.False(executadoComSucesso);
        }
    }
}