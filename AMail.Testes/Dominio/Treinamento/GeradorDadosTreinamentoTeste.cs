using AMail.Dominio;
using AMail.Dominio.Treinamento;
using AMail.Util.Colecoes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AMail.Testes.Dominio.Treinamento
{
    [TestClass]
    public class GeradorDadosTreinamentoTeste
    {
        private IGeradorCaracteristicas geradorCaracteristicas;
        private IColecaoChaveValor<Categoria, int> colecaoChaveValor; 
        private GeradorDadosTreinamento geradorDadosTreinamento;

        [TestInitialize]
        public void setup()
        {
            colecaoChaveValor = Substitute.For<IColecaoChaveValor<Categoria, int>>();
            geradorCaracteristicas = Substitute.For<IGeradorCaracteristicas>();
            geradorDadosTreinamento = new GeradorDadosTreinamento(geradorCaracteristicas, colecaoChaveValor);
        }

        [TestMethod]
        public void gerando_dados_de_treinamento()
        {
            const int valorSpam = -1;
            const int valorInbox = 1;
            
            var spam = new Categoria("spam");
            colecaoChaveValor.ObterValor(spam).Returns(valorSpam);
            var inbox = new Categoria("inbox");
            colecaoChaveValor.ObterValor(inbox).Returns(valorInbox);
            var emailsRecebidos = new[]
            {
                new EmailRecebido("Um spam", "Spam spam") { Categoria = spam },
                new EmailRecebido("Um spam", "outro spam") { Categoria = spam },
                new EmailRecebido("Mensagem de teste", "mensagem normal") { Categoria = inbox }
            };

            var caracteristicas = new[] { 3.7, 1.9 };
            geradorCaracteristicas.Extrair(Arg.Any<EmailRecebido>()).Returns(caracteristicas);

            var dadosTreinamento = geradorDadosTreinamento.Extrair(emailsRecebidos);

            var classes = new[] { valorSpam, valorSpam, valorInbox };
            dadosTreinamento.Saidas.Should().ContainInOrder(classes);
            dadosTreinamento.Entradas.Should().OnlyContain(a => a == caracteristicas);
            colecaoChaveValor.Received().ObterValor(spam);
            colecaoChaveValor.Received().ObterValor(inbox);
        }

        [TestMethod]
        public void obtendo_a_categoria_de_um_email()
        {
            const int valorSpam = -1;
            
            var spam = new Categoria("spam");
            colecaoChaveValor.ObterChave(valorSpam).Returns(spam);

            geradorDadosTreinamento.ObterCategoria(valorSpam).Should().Be(spam);

            colecaoChaveValor.Received().ObterChave(valorSpam);
        }
    }
}