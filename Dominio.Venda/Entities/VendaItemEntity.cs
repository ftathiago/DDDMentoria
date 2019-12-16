using CrossCutting.Models;
using Dominio.Venda.ValueObjects;
using Dominio.Venda.Modules;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Venda.Entities
{
    public class VendaItemEntity : IValidatableObject
    {
        public string Descricao { get; private set; }
        public ValorUnitario ValorUnitario { get; private set; }
        public ValorUnitario ValorUnitarioPromocional { get; private set; }

        public Quantidade Quantidade { get; private set; }
        public Quantidade QuantidadePromocional { get; private set; }

        private readonly ICalculadoraPrecoVendaItem _calculadoraPrecoVendaItem;

        public VendaItemEntity(VendaItemDTO vendaItemDTO, ICalculadoraPrecoVendaItem calculadoraPrecoVendaItem)
        {
            Descricao = vendaItemDTO.Descricao;
            ValorUnitario = vendaItemDTO.ValorUnitario;
            ValorUnitarioPromocional = vendaItemDTO.ValorUnitarioPromocional;
            Quantidade = vendaItemDTO.QuantidadeComprada;
            QuantidadePromocional = vendaItemDTO.QuantidadePromocional;
            _calculadoraPrecoVendaItem = calculadoraPrecoVendaItem;
        }

        public decimal ValorTotal(FormaDePagamento formaDePagamento)
        {
            if (formaDePagamento == FormaDePagamento.None)
                return 0;
            return _calculadoraPrecoVendaItem.Calcular(formaDePagamento, Quantidade, ValorUnitario,
               QuantidadePromocional, ValorUnitarioPromocional);
        }

        public bool Validar()
        {
            return Validate().Count() > 0;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Validate();
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var listaErros = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Descricao))
                listaErros.Add(new ValidationResult("Item não possui descrição"));
            if (Quantidade <= 0)
                listaErros.Add(new ValidationResult($"Quantidade do item {Descricao} não pode ser igual ou menor a zero"));
            if (ValorUnitario <= 0)
                listaErros.Add(new ValidationResult($"O valor unitário do item {Descricao} não pode ser menor ou igual a zero"));
            return listaErros;
        }
    }
}