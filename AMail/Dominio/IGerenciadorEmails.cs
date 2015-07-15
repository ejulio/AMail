using System.Collections.Generic;

namespace AMail.Dominio
{
    public interface IGerenciadorEmails
    {
        void NovoEmail(EmailRecebido emailRecebido);
        IEnumerable<EmailRecebido> ObterTodosEmails();
    }
}