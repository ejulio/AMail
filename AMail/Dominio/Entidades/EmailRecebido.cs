namespace AMail.Dominio.Entidades
{
    public class EmailRecebido
    {
        public string Assunto { get; private set; }
        public string Mensagem { get; private set; }
        public Categoria Categoria { get; set; }
        public EmailRecebido(string assunto, string mensagem)
        {
            Assunto = assunto;
            Mensagem = mensagem;
        }
    }
}