using System.Collections.Generic;
using Dominio.Venda.DTOs;
using Dominio.Venda.Entities;
using Dominio.Venda.Factories.Impl;
using Xunit;

namespace Dominio.Venda.Test.Entities
{
    public class VendaTest
    {
        /* 
        Toda venda tem um cliente
        A venda, para ser válida, 
            precisa possuir ao menos um produto
            O valor total precisa ser maior que zero (qtd * vlrUnitario || vlrPromocional)
        As formas de pagamento possíveis são:
            - Dinheiro
            - Vale Alimentação
            - Débito
            - Crédito
            - Cheque
        Cada produto possui uma "Quantidade de promoção" que caso sejam vendidos produtos suficientes, será aplicado o valor promocional
            Cada produto possui uma "Quantidade de promoção" que caso sejam vendidos produtos suficientes, será aplicado o valor promocional
            O valor promocional somente será aplicado para pagamentos:
                - Em dinheiro
                - Cartão de débito
                - Vale Alimentação
            Nos demais casos, será feito o cálculo normal.
        A venda só pode ser concluida após o pagamento ser aprovado
        A venda pode ter vários métodos de pagamento
        */
        [Theory]
        [InlineData(FormaDePagamento.None)]
        [InlineData(FormaDePagamento.Dinheiro)]
        [InlineData(FormaDePagamento.ValeAlimentacao)]
        [InlineData(FormaDePagamento.Debito)]
        [InlineData(FormaDePagamento.Credito)]
        [InlineData(FormaDePagamento.Cheque)]
        public void TestCriarVendaComFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            var cliente = new ClienteDTO("Cliente");
            var vendaDTO = new VendaDTO()
            {
                Cliente = cliente,
                FormaDePagamento = formaDePagamento,
                Itens = new List<VendaItemDTO>()
            };

            VendaEntity venda = new VendaFactory().Criar(vendaDTO);
            ClienteDTO clienteRetornado = venda.Cliente;

            Assert.Equal(formaDePagamento, venda.FormaDePagamento);
            Assert.Equal(cliente, clienteRetornado);
        }

        [Fact]
        public void TestVendaEhValidaComUmProdutoAoMenos()
        {
            var vendaDTO = new VendaDTO
            {
                Cliente = new ClienteDTO("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro,
                Itens = new List<VendaItemDTO>{
                    VendaItemDTOFactory("Produto1", 1, 1)
                }
            };
            VendaEntity venda = new VendaFactory().Criar(vendaDTO);

            bool vendaEhValida = venda.Validar();

            Assert.True(vendaEhValida);
        }

        [Fact]
        public void TestVendaNaoEhValidaSemProdutos()
        {
            VendaDTO vendaDTO = new VendaDTO
            {
                Cliente = new ClienteDTO("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro
            };

            VendaEntity venda = new VendaFactory().Criar(vendaDTO);

            bool vendaEhValida = venda.Validar();

            Assert.False(vendaEhValida);
        }

        [Fact]
        public void TestVendaNaoEhValidaComTotalMenorIgualZero()
        {
            VendaDTO vendaDTO = new VendaDTO
            {
                Cliente = new ClienteDTO("Cliente"),
                FormaDePagamento = FormaDePagamento.Dinheiro,
                Itens = new List<VendaItemDTO>{
                    VendaItemDTOFactory("Produto", 0, 1)
                }
            };
            VendaEntity venda = new VendaFactory().Criar(vendaDTO);

            bool vendaEhValida = venda.Validar();
            decimal totalVendido = venda.TotalVenda();

            Assert.False(vendaEhValida);
            Assert.Equal(0, totalVendido);
        }

        [Fact]
        public void TestVendaNaoEhValidaComFormaDePagamentoIndefinida()
        {
            VendaDTO vendaDTO = new VendaDTO
            {
                Cliente = new ClienteDTO("Cliente"),
                FormaDePagamento = FormaDePagamento.None,
                Itens = new List<VendaItemDTO>{
                    VendaItemDTOFactory("Descricao", 1, 1)
                }
            };
            VendaEntity venda = new VendaFactory().Criar(vendaDTO);

            var vendaEhValida = venda.Validar();

            Assert.False(vendaEhValida);
        }

        private VendaEntity VendaFactory(FormaDePagamento formaDePagamento = FormaDePagamento.None)
        {
            return new VendaEntity(new ClienteDTO("Cliente"), formaDePagamento);
        }

        private VendaItemDTO VendaItemDTOFactory(string Descricao, int QuantidadeComprada, int ValorUnitario,
            decimal quantidadePromocional = -1, decimal valorUnitarioPromocional = -1)
        {
            return new VendaItemDTO
            {
                Descricao = Descricao,
                QuantidadeComprada = QuantidadeComprada,
                ValorUnitario = ValorUnitario,
                QuantidadePromocional = quantidadePromocional,
                ValorUnitarioPromocional = valorUnitarioPromocional
            };
        }
    }
}
