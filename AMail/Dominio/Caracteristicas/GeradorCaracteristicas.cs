using System.Linq;

namespace AMail.Dominio
{
    public class GeradorCaracteristicas : IGeradorCaracteristicas
    {
        public double[] Extrair(EmailRecebido email)
        {
            return new[]
            {
                QuantidadeOcorrenciasDaPalavras(email.Assunto, "spam"),
                QuantidadeOcorrenciasDaPalavras(email.Mensagem, "spam")
            };
        }

        private double QuantidadeOcorrenciasDaPalavras(string texto, string palavra)
        {
            return texto.Split(' ').Count(s => s == palavra);
        }
    }
}