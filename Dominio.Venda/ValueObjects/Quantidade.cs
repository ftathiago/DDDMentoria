using System;

namespace Dominio.Venda.ValueObjects
{
    public class Quantidade
    {
        public decimal Value => _value;
        private decimal _value;

        public Quantidade(decimal quantidade)
        {
            _value = quantidade;
        }

        public bool Validar()
        {
            return _value > 0;
        }

        public static implicit operator Quantidade(decimal value)
        {
            return new Quantidade(value);
        }

        public static implicit operator decimal(Quantidade quantidade)
        {
            return quantidade.Value;
        }

    }
}