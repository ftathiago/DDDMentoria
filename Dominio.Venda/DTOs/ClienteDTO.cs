namespace Dominio.Venda.DTOs
{
    public class ClienteDTO
    {
        public string Descricao { get; set; }
        public ClienteDTO(string descricao)
        {
            this.Descricao = descricao;
        }
    }
}