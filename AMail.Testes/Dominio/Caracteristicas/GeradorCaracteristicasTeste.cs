using AMail.Dominio.Caracteristicas;
using AMail.Dominio.Entidades;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMail.Testes.Dominio.Caracteristicas
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
            var email = new EmailRecebido("Esse Desconto está com cara de bons amigos", "Um desconto especial da loja x para você que é nosso amigo");
            var caracteristicas = geradorCaracteristicas.Extrair(email);

            caracteristicas.Should().HaveCount(2);
            caracteristicas[0].Should().Be(2); // amigos + amigos
            caracteristicas[1].Should().Be(3); // desconto + desconto + loja 
        }
    }
}
