namespace Venda.Dominio.DTO
{
    public class ClienteDTO
    {
        public int ID { get; set; }
        public ClienteDTO(int id)
        {
            this.ID = id;
        }
    }
}