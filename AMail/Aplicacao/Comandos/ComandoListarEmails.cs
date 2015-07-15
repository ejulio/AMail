using AMail.Dominio;
using System;
using System.Linq;

namespace AMail.Aplicacao.Comandos
{
    public class ComandoListarEmails : IComando
    {
        private readonly IGerenciadorEmails gerenciadorEmails;

        public ComandoListarEmails(IGerenciadorEmails gerenciadorEmails)
        {
            this.gerenciadorEmails = gerenciadorEmails;
        }

        public void Executar()
        {
            var emailsAgrupados = gerenciadorEmails.ObterTodosEmails()
                .GroupBy(e => e.Categoria, (c, e) => new {Categoria = c, Emails = e});

            foreach (var grupo in emailsAgrupados)
            {
                Console.WriteLine(grupo.Categoria.Descricao);
                foreach (var email in grupo.Emails)
                {
                    Console.WriteLine(":::{0}", email.Assunto);
                }
            }
        } 
    }
}