using AMail.Dominio;
using AMail.Dominio.Treinamento;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AMail.Testes.Dominio.Treinamento
{
    [TestClass]
    public class GeradorDadosTreinamentoTeste
    {
        private IGeradorCaracteristicas geradorCaracteristicas;
        private GeradorDadosTreinamento geradorDadosTreinamento;

        [TestInitialize]
        public void setup()
        {
            geradorCaracteristicas = Substitute.For<IGeradorCaracteristicas>();
            geradorDadosTreinamento = new GeradorDadosTreinamento(geradorCaracteristicas);
        }

        [TestMethod]
        public void gerando_dados_de_treinamento()
        {
            var spam = new Categoria("spam");
            var inbox = new Categoria("inbox");
            var emailsRecebidos = new[]
            {
                new EmailRecebido("Um spam", "Spam spam") { Categoria = spam },
                new EmailRecebido("Um spam", "outro spam") { Categoria = spam },
                new EmailRecebido("Mensagem de teste", "mensagem normal") { Categoria = inbox }
            };

            var dadosTreinamento = geradorDadosTreinamento.Extrair(emailsRecebidos);

            dadosTreinamento.QuantidadeClasses.Should().Be(2);
            //dadosTreinamento.Saidas.Should().Be();
        }
    }
}