using AMail.Util.Colecoes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMail.Testes.Util.Colecoes
{
    [TestClass]
    public class ColecaoChaveValorTeste
    {
        [TestMethod]
        public void obtendo_valor_pela_chave()
        {
            var colecaoChaveValor = new ColecaoChaveValor<string, int>();
            var chave = "chave";
            var valor = 1;

            colecaoChaveValor.Adicionar(chave, valor);

            var valorObtido = colecaoChaveValor.ObterValor(chave);

            valorObtido.Should().Be(valor);
        }

        [TestMethod]
        public void obtendo_chave_pelo_valor()
        {
            var colecaoChaveValor = new ColecaoChaveValor<string, int>();
            var chave = "chave";
            var valor = 1;

            colecaoChaveValor.Adicionar(chave, valor);

            var chaveObtida = colecaoChaveValor.ObterChave(valor);

            chaveObtida.Should().Be(chave);
        }
    }
}