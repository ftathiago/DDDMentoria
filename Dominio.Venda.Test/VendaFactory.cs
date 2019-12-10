namespace Dominio.Venda.Test
{
    public class VendaFactory : IVendaFactory
    {
        public Venda Criar(VendaDTO vendaDTO)
        {
            var venda = CriarVenda(vendaDTO);
            AdicionarItens(venda, vendaDTO);

            return venda;
        }

        private Venda CriarVenda(VendaDTO vendaDTO)
        {
            return new Venda(vendaDTO.Cliente, vendaDTO.FormaDePagamento);
        }

        private void AdicionarItens(Venda venda, VendaDTO vendaDTO)
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