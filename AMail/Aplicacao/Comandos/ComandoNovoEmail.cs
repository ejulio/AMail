using AMail.Dominio;
using System;
using AMail.Dominio.Entidades;

namespace AMail.Aplicacao.Comandos
{
    public class ComandoNovoEmail : IComando
    {
        private readonly IGerenciadorEmails gerenciadorEmails;

        public ComandoNovoEmail(IGerenciadorEmails gerenciadorEmails)
        {
            this.gerenciadorEmails = gerenciadorEmails;
        }

        public void Executar()
        {
            Console.Write("Assunto: ");
            var assunto = Console.ReadLine();

            Console.Write("Mensagem: ");
            var mensagem = Console.ReadLine();

            var emailRecebido = new EmailRecebido(assunto, mensagem);
            gerenciadorEmails.NovoEmail(emailRecebido);
        }
    }
}