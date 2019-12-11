using Dominio.Venda.DTO;
using Dominio.Venda.Entity;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dominio.Venda.Test
{
    public class VendaFactoryTest
    {
        [Fact]
        public void TestCriarFabrica()
        {
            IVendaFactory vendaFactory = new VendaFactory();
            var vendaDTO = new VendaDTO();

            VendaEntity venda = vendaFactory.Criar(vendaDTO);

            Assert.NotNull(venda);
            Assert.IsAssignableFrom<VendaEntity>(venda);
        }

        [Fact]
        public void TestCriarVendaComItem()
        {
            var vendaDTO = new VendaDTO
            {
                Cliente = new ClienteDTO("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro,
                Itens = new List<VendaItemDTO>{
                    new VendaItemDTO{
                        Descricao = "Produto1",
                        QuantidadeComprada = 10,
                        QuantidadePromocional = 10,
                        ValorUnitario = 10,
                        ValorUnitarioPromocional = 10
                    },
                    new VendaItemDTO {
                        Descricao = "Produto2",
                        QuantidadeComprada = 20,
                        QuantidadePromocional = 20,
                        ValorUnitario = 20,
                        ValorUnitarioPromocional = 20
                    }
                }
            };
            IVendaFactory vendaFactory = new VendaFactory();

            VendaEntity venda = vendaFactory.Criar(vendaDTO);

            Assert.Equal(2, venda.Itens.Count());
        }
    }
}