
using AMail.Dominio;
using System;

namespace AMail
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * TODO:
             * - Retornar a categoria do Email ao invés do número da classe no ClassificadorEmail
             */

            var spam = new Categoria("spam");
            var inbox = new Categoria("inbox");
            var listaEmails = new[]
            {
                new EmailRecebido("Este é um spam spam spam", "Corpo do spam que corresponde à um spam") { Categoria = spam }, // [3, 2]
                new EmailRecebido("Essa mensagem não é spam", "Este texto está ok") { Categoria = inbox }, // [1, 0]
                new EmailRecebido("Spam! Ser ou não ser spam", "Isso sim é um spam na minha lista de spam") { Categoria = spam }, // [2, 2]
                new EmailRecebido("Dude, I'm a super spam", "Estamos aqui com um novo spam na sua lista de spam") { Categoria = spam }, // [1, 2]
                new EmailRecebido("Sem chance dessa oferta ser um spam", "Este email até poderia ser um spam") { Categoria = inbox } // [1, 1]
            };

            var classificadorEmail = new ClassificadorEmailFactory().Criar();

            classificadorEmail.Treinar(listaEmails);

            var novoSpam = new EmailRecebido("spam", "spam spam spam");
            var novoInbox = new EmailRecebido("spam spam spam spam", "mensagem da inbox");

            var classeNovoSpam = classificadorEmail.Classificar(novoSpam);
            var classeNovoInbox = classificadorEmail.Classificar(novoInbox);
        
            Console.WriteLine("Spam: {0}; Inbox: {1}", classeNovoSpam, classeNovoInbox);

            Console.ReadKey();
        }
    }
}
