namespace AMail.Dominio.Treinamento
{
    public interface IGeradorDadosTreinamento
    {
        DadosTreinamento Extrair(EmailRecebido[] emailsRecebidos);
    }
}