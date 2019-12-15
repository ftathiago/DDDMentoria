namespace CrossCutting.Models
{
    public class MensagemErro
    {
        public MensagemErro(string mensagemErro)
        {
            Mensagem = mensagemErro;
        }

        public string Mensagem { get; private set; }
    }
}