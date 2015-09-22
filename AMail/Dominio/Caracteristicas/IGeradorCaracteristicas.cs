using AMail.Dominio.Entidades;

namespace AMail.Dominio.Caracteristicas
{
    public interface IGeradorCaracteristicas
    {
        double[] Extrair(EmailRecebido email);
    }
}