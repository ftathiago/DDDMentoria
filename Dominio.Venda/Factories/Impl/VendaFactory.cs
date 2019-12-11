using Dominio.Venda.DTO;
using Dominio.Venda.Entity;

namespace Dominio.Venda
{
    public class VendaFactory : IVendaFactory
    {
        public VendaEntity Criar(VendaDTO vendaDTO)
        {
            var venda = CriarVenda(vendaDTO);
            AdicionarItens(venda, vendaDTO);

            return venda;
        }

        private VendaEntity CriarVenda(VendaDTO vendaDTO)
        {
            return new VendaEntity(vendaDTO.Cliente, vendaDTO.FormaDePagamento);
        }

        private void AdicionarItens(VendaEntity venda, VendaDTO vendaDTO)
        {
            if (vendaDTO.Itens == null)
                return;
            foreach (var item in vendaDTO.Itens)
            {
                var vendaItem = new VendaItem(item, new CalculadoraPrecoVendaItem());
                venda.AdicionarVendaItem(vendaItem);
            }
        }
    }
}