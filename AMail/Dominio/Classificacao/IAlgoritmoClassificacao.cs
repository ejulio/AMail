using AMail.Dominio.Treinamento;

namespace AMail.Dominio.Classificacao
{
    public interface IAlgoritmoClassificacao
    {
        int Classificar(double[] caracteristicas);
        void Treinar(DadosTreinamento dadosTreinamento); 
    }
}