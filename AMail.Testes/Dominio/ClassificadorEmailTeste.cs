using AMail.Dominio;
using AMail.Dominio.Classificacao;
using AMail.Dominio.Treinamento;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AMail.Testes.Dominio
{
    [TestClass]
    public class ClassificadorEmailTeste
    {
        private IGeradorCaracteristicas geradorCaracteristicas;
        private IGeradorDadosTreinamento geradorDadosTreinamento;
        private IAlgoritmoClassificacao algoritmoClassificacao;
        private ClassificadorEmail classificadorEmail;

        [TestInitialize]
        public void setup()
        {
            geradorCaracteristicas = Substitute.For<IGeradorCaracteristicas>();
            geradorDadosTreinamento = Substitute.For<IGeradorDadosTreinamento>();
            algoritmoClassificacao = Substitute.For<IAlgoritmoClassificacao>();
            classificadorEmail = new ClassificadorEmail(algoritmoClassificacao, geradorCaracteristicas, geradorDadosTreinamento);
        }

        [TestMethod]
        public void treinando_algoritmo_de_classificacao()
        {
            var emailsRecebidos = new[]
            {
                new EmailRecebido("email", "email"),
                new EmailRecebido("email", "email"),
                new EmailRecebido("email", "email")
            };

            var dadosTreinamento = new DadosTreinamento();
            geradorDadosTreinamento.Extrair(emailsRecebidos).Returns(dadosTreinamento);

            classificadorEmail.Treinar(emailsRecebidos);

            geradorDadosTreinamento.Received().Extrair(emailsRecebidos);
            algoritmoClassificacao.Received().Treinar(dadosTreinamento);
        }

        [TestMethod]
        public void classificando_email()
        {
            var email = new EmailRecebido("email", "email");
            const int classeEsperada = 1;
            var categoriaEsperada = new Categoria("Esperada");
            geradorDadosTreinamento.ObterCategoria(classeEsperada).Returns(categoriaEsperada);

            var caracteristicas = new[] {2.6, 1.9};
            geradorCaracteristicas.Extrair(email).Returns(caracteristicas);
            algoritmoClassificacao.Classificar(caracteristicas).Returns(classeEsperada);

            var categoria = classificadorEmail.Classificar(email);

            algoritmoClassificacao.Received().Classificar(caracteristicas);
            categoria.Should().Be(categoriaEsperada);
        }
    }
}