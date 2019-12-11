using System;

namespace Dominio.Venda.ValueObjects
{
    public class ValorUnitario
    {
        public decimal Value => _valor;
        private readonly decimal _valor;
        public ValorUnitario(decimal valor)
        {
            _valor = valor;
        }

        public bool Validar()
        {
            return true;
        }

        public static implicit operator ValorUnitario(decimal valor)
        {
            return new ValorUnitario(valor);
        }
    }
}