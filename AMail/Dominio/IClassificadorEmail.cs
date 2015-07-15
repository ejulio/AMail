namespace AMail.Dominio
{
    public interface IClassificadorEmail
    {
        Categoria Classificar(EmailRecebido email);
    }
}