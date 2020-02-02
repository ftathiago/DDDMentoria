namespace Venda.Application.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public ClienteModel(string nome)
        {
            this.Nome = nome;
        }
    }
}