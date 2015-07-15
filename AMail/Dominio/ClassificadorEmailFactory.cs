using AMail.Dominio.Classificacao;
using AMail.Dominio.Treinamento;
using AMail.Util.Colecoes;

namespace AMail.Dominio
{
    public class ClassificadorEmailFactory
    {
        private readonly Categoria Spam = new Categoria("spam");
        private readonly Categoria Inbox = new Categoria("inbox");

        public ClassificadorEmail Criar()
        {
            var colecaoChaveValor = new ColecaoChaveValor<Categoria, int>();
            colecaoChaveValor.Adicionar(Spam, -1);
            colecaoChaveValor.Adicionar(Inbox, 1);

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
                new EmailRecebido("Este é um spam spam spam spam", "Corpo do email que corresponde à um spam") { Categoria = Spam }, // [4, 1]
                new EmailRecebido("Essa mensagem não é spam", "Este texto está ok") { Categoria = Inbox }, // [1, 0]
                new EmailRecebido("Spam Super Spam Ser ou não ser spam", "Isso sim é um spam na minha lista de spam") { Categoria = Spam }, // [3, 2]
                new EmailRecebido("Dude, I'm a super spam", "Spam Estamos aqui com um novo spam na sua lista de spam") { Categoria = Spam }, // [1, 3]
                new EmailRecebido("Sem chance dessa oferta ser um spam", "Este email até poderia ser um spam") { Categoria = Inbox } // [1, 1]
            };

            classificadorEmail.Treinar(listaEmails);
        }
    }
}