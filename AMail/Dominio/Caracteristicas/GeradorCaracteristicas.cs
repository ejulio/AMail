using AMail.Dominio.Entidades;
using System.Linq;

namespace AMail.Dominio.Caracteristicas
{
    public class GeradorCaracteristicas : IGeradorCaracteristicas
    {
        private string[] palavrasRedesSociais = new[] { "amigo", "amigos", "perfil" };
        private string[] palavrasAnuncios = new[] { "desconto", "descontão", "oferta", "loja" };

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
            return texto.Split(' ').Count(palavra => palavrasRedesSociais.Contains(palavra));
        }

        private double ContarPalavrasAnuncio(string texto)
        {
            return texto.Split(' ').Count(palavra => palavrasAnuncios.Contains(palavra));
        }
    }
}