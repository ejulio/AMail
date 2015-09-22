using AMail.Dominio;
using AMail.Dominio.Entidades;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AMail.Testes.Dominio
{
    [TestClass]
    public class GerenciadorEmailsTeste
    {
        private IClassificadorEmail classificadorEmail;
        private GerenciadorEmails gerenciadorEmails;

        [TestInitialize]
        public void setup()
        {
            classificadorEmail = Substitute.For<IClassificadorEmail>();
            gerenciadorEmails = new GerenciadorEmails(classificadorEmail);
        }

        [TestMethod]
        public void recebendo_emails()
        {
            var emailRecebido = new EmailRecebido("Email", "Email");
            gerenciadorEmails.NovoEmail(emailRecebido);

            gerenciadorEmails.ObterTodosEmails().Should().Contain(emailRecebido);
        }

        [TestMethod]
        public void classificando_emails_recebidos()
        {
            var emailRecebido = new EmailRecebido("Email", "Email");
            var categoria = new Categoria("Teste");
            classificadorEmail.Classificar(emailRecebido).Returns(categoria);

            gerenciadorEmails.NovoEmail(emailRecebido);

            emailRecebido.Categoria.Should().Be(categoria);
        }
    }
}