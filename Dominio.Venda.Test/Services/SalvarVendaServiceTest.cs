using Dominio.Venda.Repository;
using Dominio.Venda.Entities;
using Dominio.Venda.Services;
using Dominio.Venda.Services.Impl;
using Xunit;
using Moq;

namespace Dominio.Venda.Test.Services
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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);

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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar(venda);

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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar(venda);

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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar(venda);

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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);
            bool executadoComSucesso = salvarVendaService.Executar(venda);

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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);
            salvarVendaService.Executar(venda);
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

            ISalvarVendaService salvarVendaService = new SalvarVendaService(vendaRepository);
            salvarVendaService.Executar(venda);
            var mensagemErro = salvarVendaService.MensagemErro;

            Assert.Equal(mensagemDeRetornoEsperada, mensagemErro);
        }
    }
}