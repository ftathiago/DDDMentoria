namespace Dominio.Venda.Test
{
    public class VendaFactory : IVendaFactory
    {
        public Venda Criar(VendaDTO vendaDTO)
        {
            var venda = new Venda(vendaDTO.Cliente, vendaDTO.FormaDePagamento);
            if (vendaDTO.Itens == null)
                return venda;
            foreach (var item in vendaDTO.Itens)
            {
                var vendaItem = new VendaItem(item, new CalculadoraPrecoVendaItem());
                venda.AdicionarVendaItem(vendaItem);
            }
            return venda;
        }
    }
}