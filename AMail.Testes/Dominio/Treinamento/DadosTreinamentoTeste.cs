using AMail.Dominio.Treinamento;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMail.Testes.Dominio.Treinamento
{
    [TestClass]
    public class DadosTreinamentoTeste
    {
        [TestMethod]
        public void adicionando_dados_de_treinamento()
        {
            var dadosTreinamento = new DadosTreinamento();

            var caracteristicas = new[] { 2.0, 2.5 };
            var classe = 0;

            dadosTreinamento.Adicionar(caracteristicas, classe);

            dadosTreinamento.Saidas.Should().HaveCount(1);
            dadosTreinamento.Saidas.Should().OnlyContain(s => s == 0);
            dadosTreinamento.Entradas.Should().HaveCount(1);
            dadosTreinamento.Entradas.Should().OnlyContain(a => a[0] == caracteristicas[0] && a[1] == caracteristicas[1]);
        }

        [TestMethod]
        public void adicionando_dados_de_treinamento2()
        {
            var dadosTreinamento = new DadosTreinamento();

            var caracteristicas = new[]
            {
                new[] { 2.0, 2.5 },
                new[] { 1.3, 2.0 },
                new[] { 8.1, 3.5 },
                new[] { 2.2, 4.5 }
            };
            var classes = new[] { 0, 1, 1, 0 };

            dadosTreinamento.Adicionar(caracteristicas[0], classes[0]);
            dadosTreinamento.Adicionar(caracteristicas[1], classes[1]);
            dadosTreinamento.Adicionar(caracteristicas[2], classes[2]);
            dadosTreinamento.Adicionar(caracteristicas[3], classes[3]);

            dadosTreinamento.Saidas.Should().HaveSameCount(classes);
            dadosTreinamento.Entradas.Should().HaveSameCount(caracteristicas);

            for (var i = 0; i < caracteristicas.Length; i++)
            {
                dadosTreinamento.Entradas[i].Should().ContainInOrder(caracteristicas[i]);
                dadosTreinamento.Saidas[i].Should().Be(classes[i]);
            }
        }
    }
}