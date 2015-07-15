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
                new EmailRecebido("Este é um spam spam spam", "Corpo do spam que corresponde à um spam") { Categoria = Spam }, // [3, 2]
                new EmailRecebido("Essa mensagem não é spam", "Este texto está ok") { Categoria = Inbox }, // [1, 0]
                new EmailRecebido("Spam! Ser ou não ser spam", "Isso sim é um spam na minha lista de spam") { Categoria = Spam }, // [2, 2]
                new EmailRecebido("Dude, I'm a super spam", "Estamos aqui com um novo spam na sua lista de spam") { Categoria = Spam }, // [1, 2]
                new EmailRecebido("Sem chance dessa oferta ser um spam", "Este email até poderia ser um spam") { Categoria = Inbox } // [1, 1]
            };

            classificadorEmail.Treinar(listaEmails);
        }
    }
}