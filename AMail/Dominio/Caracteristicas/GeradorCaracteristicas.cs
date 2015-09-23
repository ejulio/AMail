using AMail.Dominio.Entidades;
using System.Linq;

namespace AMail.Dominio.Caracteristicas
{
    public class GeradorCaracteristicas : IGeradorCaracteristicas
    {
        private string[] palavrasRedesSociais = { "amigo", "amigos", "perfil" };
        private string[] palavrasAnuncios = { "desconto", "descontão", "oferta", "lojinha", "loja", "comprar", "comprasse" };

        public double[] Extrair(EmailRecebido email)
        {
            return new[]
            {
                ContarPalavrasSocial(email.Assunto) + ContarPalavrasSocial(email.Mensagem),
                ContarPalavrasAnuncio(email.Assunto) + ContarPalavrasAnuncio(email.Mensagem)
            };
        }

        private double ContarPalavrasSocial(string texto)
        {
            return texto.Split(' ').Count(palavra => palavrasRedesSociais.Contains(palavra.ToLower()));
        }

        private double ContarPalavrasAnuncio(string texto)
        {
            return texto.Split(' ').Count(palavra => palavrasAnuncios.Contains(palavra.ToLower()));
        }
    }
}