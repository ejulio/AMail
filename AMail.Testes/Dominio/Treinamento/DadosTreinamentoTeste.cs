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

            dadosTreinamento.QuantidadeClasses.Should().Be(1);
            dadosTreinamento.Saidas.Should().HaveCount(1);
            dadosTreinamento.Saidas.Should().OnlyContain(s => s == 0);
            dadosTreinamento.Entradas.Should().HaveCount(1);
            dadosTreinamento.Entradas.Should().OnlyContain(a => a[0] == caracteristicas[0] && a[1] == caracteristicas[1]);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            
        }
    }
}