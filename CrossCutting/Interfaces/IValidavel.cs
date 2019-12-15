using System.Collections.Generic;
using CrossCutting.Models;

namespace CrossCutting.Interfaces
{
    public interface IValidavel
    {
        bool EhValido();
        IEnumerable<MensagemErro> PegarMensagensErro();
    }
}