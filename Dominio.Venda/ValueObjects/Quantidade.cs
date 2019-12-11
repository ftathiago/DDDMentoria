using System;

namespace Dominio.Venda.ValueObjects
{
    public class Quantidade
    {
        public decimal Value => _value;
        private decimal _value;
        public Quantidade(decimal quantidade)
        {

        }

        public static implicit operator Quantidade(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}