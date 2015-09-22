using System.Collections.Generic;
using AMail.Dominio.Entidades;

namespace AMail.Dominio
{
    public class GerenciadorEmails : IGerenciadorEmails
    {
        private readonly IClassificadorEmail classificadorEmail;
        private IList<EmailRecebido> emailsRecebidos;

        public GerenciadorEmails(IClassificadorEmail classificadorEmail)
        {
            this.classificadorEmail = classificadorEmail;
            emailsRecebidos = new List<EmailRecebido>();
        }

        public void NovoEmail(EmailRecebido emailRecebido)
        {
            var categoriaEmail = classificadorEmail.Classificar(emailRecebido);
            emailRecebido.Categoria = categoriaEmail;
            emailsRecebidos.Add(emailRecebido);
        }

        public IEnumerable<EmailRecebido> ObterTodosEmails()
        {
            return emailsRecebidos;
        }
    }
}