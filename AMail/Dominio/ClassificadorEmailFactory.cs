using AMail.Dominio.Caracteristicas;
using AMail.Dominio.Classificacao;
using AMail.Dominio.Entidades;
using AMail.Dominio.Treinamento;
using AMail.Util.Colecoes;

namespace AMail.Dominio
{
    public class ClassificadorEmailFactory
    {
        private readonly Categoria Ofertas = new Categoria("ofertas");
        private readonly Categoria Social = new Categoria("social");
        private readonly Categoria Inbox = new Categoria("inbox");

        public ClassificadorEmail Criar()
        {
            var colecaoChaveValor = new ColecaoChaveValor<Categoria, int>();
            colecaoChaveValor.Adicionar(Inbox, 0);
            colecaoChaveValor.Adicionar(Ofertas, 1);
            colecaoChaveValor.Adicionar(Social, 2);

            var svm = new Svm();
            var geradorCaracteristicas = new GeradorCaracteristicas();
            var geradorDadosTreinamento = new GeradorDadosTreinamento(geradorCaracteristicas, colecaoChaveValor);
            var classificadorEmail = new ClassificadorEmail(svm, geradorCaracteristicas, geradorDadosTreinamento);

            TreinarClassificador(classificadorEmail);

            return classificadorEmail;
        }

        private void TreinarClassificador(ClassificadorEmail classificadorEmail)
        {
            var listaEmails = new[]
            {
                new EmailRecebido("Vai perder? Só hoje esse descontão !", "Só hoje na lojinha do joão tem esse desconto") { Categoria = Ofertas }, // [0, 3]
                new EmailRecebido("Tem desconto aqui", "Só hoje para quem comprar pelo nosso perfil na rede social") { Categoria = Ofertas }, // [1, 2]
                new EmailRecebido("Atualizamos o nosso perfil", "Olá pessoa, tudo bem? Você já conferiu o perfil atualizado da nossa loja") { Categoria = Social }, // [2, 1]
                new EmailRecebido("O super perfil", "O seu amigo Teste atualizou o perfil") { Categoria = Social }, // [3, 0]
                new EmailRecebido("Desconto", "Ae manolo, já comprasse aquele celular?") { Categoria = Inbox }, // [0, 2]
                new EmailRecebido("Notícia", "Divulgada foto de perfil do meliante") { Categoria = Inbox } // [1, 0]
            };

            classificadorEmail.Treinar(listaEmails);
        }
    }
}