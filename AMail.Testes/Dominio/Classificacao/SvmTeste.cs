using AMail.Dominio.Classificacao;
using AMail.Dominio.Treinamento;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AMail.Testes.Dominio.Classificacao
{
    [TestClass]
    public class SvmTeste
    {
        [TestMethod]
        public void classificando_antes_de_treinar()
        {
            var svm = new Svm();
            var caracteristicas = new[] {1.0, 1.2};

            Action acao = () => svm.Classificar(caracteristicas);

            acao.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void classificando_caracteristicas()
        {
            var dadosTreinamento = new DadosTreinamento();
            dadosTreinamento.Adicionar(new [] { 1.0, 1.0 }, 0);
            dadosTreinamento.Adicionar(new [] { 0.5, 0.5 }, 1);
            dadosTreinamento.Adicionar(new [] { 1.5, 1.5 }, 2);

            var svm = new Svm();

            svm.Treinar(dadosTreinamento);

            var classe = svm.Classificar(new[] {0.3, 0.3});
            classe.Should().Be(1);
        }
    }
}