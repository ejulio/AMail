namespace AMail.Dominio.Treinamento
{
    public class GeradorDadosTreinamento
    {
        private readonly IGeradorCaracteristicas geradorCaracteristicas;

        public GeradorDadosTreinamento(IGeradorCaracteristicas geradorCaracteristicas)
        {
            this.geradorCaracteristicas = geradorCaracteristicas;
        }

        public DadosTreinamento Extrair(EmailRecebido[] emailsRecebidos)
        {
            throw new System.NotImplementedException();
        }
    }
}