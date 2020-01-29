using CrossCutting.Models;
using Dominio.Venda.Entities;
using Application.Venda.Factories;
using Application.Venda.Factories.Impl;
using Application.Venda.Models;
using Application.Venda.Modules;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Xunit;

namespace Application.Venda.Test
{
    public class VendaFactoryTest
    {
        [Fact]
        public void TestCriarFabrica()
        {
            IMapper mapper = PegarMapper();
            IVendaFactory vendaFactory = new VendaFactory(mapper);
            var vendaModel = new VendaModel();
            vendaModel.Cliente = new ClienteModel(string.Empty);

            VendaEntity venda = vendaFactory.Criar(vendaModel);

            Assert.NotNull(venda);
            Assert.IsAssignableFrom<VendaEntity>(venda);
        }

        [Fact]
        public void TestCriarVendaComItem()
        {
            var vendaModel = new VendaModel
            {
                Cliente = new ClienteModel("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro,
                Itens = new List<VendaItemModel>{
                    new VendaItemModel{
                        Descricao = "Produto1",
                        QuantidadeComprada = 10,
                        QuantidadePromocional = 10,
                        ValorUnitario = 10,
                        ValorUnitarioPromocional = 10
                    },
                    new VendaItemModel {
                        Descricao = "Produto2",
                        QuantidadeComprada = 20,
                        QuantidadePromocional = 20,
                        ValorUnitario = 20,
                        ValorUnitarioPromocional = 20
                    }
                }
            };
            IMapper mapper = PegarMapper();
            IVendaFactory vendaFactory = new VendaFactory(mapper);

            VendaEntity venda = vendaFactory.Criar(vendaModel);

            Assert.Equal(2, venda.Itens.Count());
        }

        public IMapper PegarMapper()
        {
            return AutoMapperConfig.PegarMapper();
        }
    }
}