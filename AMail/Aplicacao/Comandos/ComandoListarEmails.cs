using AMail.Dominio;
using AMail.Dominio.Caracteristicas;
using System;
using System.Linq;

namespace AMail.Aplicacao.Comandos
{
    public class ComandoListarEmails : IComando
    {
        private readonly IGerenciadorEmails gerenciadorEmails;
        private readonly IGeradorCaracteristicas geradorCaracteristicas;

        public ComandoListarEmails(IGerenciadorEmails gerenciadorEmails, IGeradorCaracteristicas geradorCaracteristicas)
        {
            this.gerenciadorEmails = gerenciadorEmails;
            this.geradorCaracteristicas = geradorCaracteristicas;
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
                    var caracteristicas = geradorCaracteristicas.Extrair(email);
                    Console.WriteLine("::: {0} [{1}, {2}]", email.Assunto, caracteristicas[0], caracteristicas[1]);
                }
                
                Console.WriteLine();
            }
        } 
    }
}