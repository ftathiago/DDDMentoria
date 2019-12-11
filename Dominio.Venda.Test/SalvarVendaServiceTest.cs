using Dominio.Venda.Repository;
using Dominio.Venda.Entity;
using Dominio.Venda.Services;
using Dominio.Venda.Services.Impl;
using Xunit;
using Moq;

namespace Dominio.Venda.Test
{
    public class SalvarVendaServiceTest
    {
        [Fact]
        public void TestCriarServicoSalvarVenda()
        {
            var venda = new Mock<VendaEntity>().Object;
            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);

            Assert.NotNull(salvarVendaService);
        }

        [Fact]
        public void TestExecutarServicoComSucesso()
        {
            var vendaMock = new Mock<VendaEntity>();
            vendaMock.SetReturnsDefault<bool>(true);
            VendaEntity venda = vendaMock.Object;

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
            var vendaMock = new Mock<VendaEntity>();
            vendaMock.SetReturnsDefault<bool>(false);
            VendaEntity venda = vendaMock.Object;

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
            var mockVenda = new Mock<VendaEntity>();
            mockVenda.SetReturnsDefault<bool>(true);
            VendaEntity venda = mockVenda.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.True(executadoComSucesso);
        }

        [Fact]
        public void TestExecutaComSucessoQuandoRepositorioNaoGrava()
        {
            var mockVenda = new Mock<VendaEntity>();
            mockVenda.SetReturnsDefault<bool>(true);
            VendaEntity venda = mockVenda.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(false);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.False(executadoComSucesso);
        }

        [Fact]
        public void TestServicoPossuiMensagemDeErroAoTentarSalvarVendaInvalida()
        {
            var mensagemDeRetornoEsperada = "A venda está invalida!";

            var vendaMock = new Mock<VendaEntity>();
            vendaMock.SetReturnsDefault<bool>(false);
            VendaEntity venda = vendaMock.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(true);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            salvarVendaService.Executar();
            var mensagemErro = salvarVendaService.MensagemErro;

            Assert.Equal(mensagemDeRetornoEsperada, mensagemErro);
        }
        [Fact]
        public void TestServicoPossuiMensagemDeErroQuandoRepositorioNaoSalva()
        {
            var mensagemDeRetornoEsperada = "Não foi possível salvar a venda";

            var vendaMock = new Mock<VendaEntity>();
            vendaMock.SetReturnsDefault<bool>(true);
            VendaEntity venda = vendaMock.Object;

            var vendaRepositoryMock = new Mock<IVendaRepository>();
            vendaRepositoryMock.SetReturnsDefault<bool>(false);
            IVendaRepository vendaRepository = vendaRepositoryMock.Object;

            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda, vendaRepository);
            salvarVendaService.Executar();
            var mensagemErro = salvarVendaService.MensagemErro;

            Assert.Equal(mensagemDeRetornoEsperada, mensagemErro);
        }
    }
}