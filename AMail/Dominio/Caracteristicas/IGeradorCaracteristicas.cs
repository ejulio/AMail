namespace AMail.Dominio
{
    public interface IGeradorCaracteristicas
    {
        double[] Extrair(EmailRecebido email);
    }
}