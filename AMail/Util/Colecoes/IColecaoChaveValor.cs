namespace AMail.Util.Colecoes
{
    public interface IColecaoChaveValor<TChave, TValor>
    {
        void Adicionar(TChave chave, TValor valor);
        TValor ObterValor(TChave chave);
        TChave ObterChave(TValor valor);
    }
}