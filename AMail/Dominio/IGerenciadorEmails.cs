using System.Collections.Generic;
using AMail.Dominio.Entidades;

namespace AMail.Dominio
{
    public interface IGerenciadorEmails
    {
        void NovoEmail(EmailRecebido emailRecebido);
        IEnumerable<EmailRecebido> ObterTodosEmails();
    }
}