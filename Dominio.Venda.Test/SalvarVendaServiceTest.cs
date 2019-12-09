using Xunit;

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
            var venda = new Venda("Cliente", FormaDePagamento.Dinheiro);
            ISalvarVendaService salvarVendaService = new SalvarVendaService(venda);

            bool executadoComSucesso = salvarVendaService.Executar();

            Assert.True(executadoComSucesso);
        }
    }
}