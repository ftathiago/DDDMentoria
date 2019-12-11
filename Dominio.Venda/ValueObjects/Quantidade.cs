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

        public static implicit operator Quantidade(decimal value)
        {
            return new Quantidade(value);
        }

        public bool Validar()
        {
            return _value > 0;
        }
    }
}