using System.Collections.Generic;

namespace AMail.Util.Colecoes
{
    public class ColecaoChaveValor<TChave, TValor> : IColecaoChaveValor<TChave, TValor>
    {
        private IList<TChave> chaves;
        private IList<TValor> valores;

        public ColecaoChaveValor()
        {
            chaves = new List<TChave>();
            valores = new List<TValor>();
        }

        public void Adicionar(TChave chave, TValor valor)
        {
            chaves.Add(chave);
            valores.Add(valor);
        }

        public TValor ObterValor(TChave chave)
        {
            var indice = chaves.IndexOf(chave);
            return valores[indice];
        }

        public TChave ObterChave(TValor valor)
        {
            var indice = valores.IndexOf(valor);
            return chaves[indice];
        }
    }
}