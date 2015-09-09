using AMail.Dominio;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMail.Testes
{
    [TestClass]
    public class GeradorCaracteristicasTeste
    {
        private GeradorCaracteristicas geradorCaracteristicas;

        [TestInitialize]
        public void setup()
        {
            geradorCaracteristicas = new GeradorCaracteristicas();
        }

        [TestMethod]
        public void extraindo_caracteristicas_de_um_email()
        {
            var email = new EmailRecebido("Este é um spam que contém Spam", "Corpo da mensagem que é considerada um spam Spam ...");
            var caracteristicas = geradorCaracteristicas.Extrair(email);

            caracteristicas.Should().HaveCount(2);
            caracteristicas[0].Should().Be(2);
            caracteristicas[1].Should().Be(2);
        }
    }
}
