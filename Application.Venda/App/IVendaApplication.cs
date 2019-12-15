using System.Collections.Generic;
using CrossCutting.Models;

namespace Application.Venda.App
{
    public interface IVendaApplication
    {
        bool ProcessarVenda(VendaDTO vendaDTO);
        IEnumerable<MensagemErro> MensagemErro();
    }
}