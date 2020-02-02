namespace Venda.Application.Models
{
    public class ClienteModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public ClienteModel(int id, string nome)
        {
            ID = id;
            Nome = nome;
        }

        public ClienteModel() { }
    }
}