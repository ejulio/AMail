using AMail.Dominio.Entidades;

namespace AMail.Dominio.Treinamento
{
    public interface IGeradorDadosTreinamento
    {
        DadosTreinamento Extrair(EmailRecebido[] emailsRecebidos);
        Categoria ObterCategoria(int classe);
    }
}