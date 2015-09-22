using AMail.Dominio.Entidades;

namespace AMail.Dominio
{
    public interface IClassificadorEmail
    {
        Categoria Classificar(EmailRecebido email);
    }
}