
using AMail.Aplicacao.Comandos;
using AMail.Dominio;

namespace AMail
{
    class Program
    {
        static void Main(string[] args)
        {
            var classificadorEmail = new ClassificadorEmailFactory().Criar();
            var gerenciadorEmails = new GerenciadorEmails(classificadorEmail);
            var gerenciadorComandos = new GerenciadorComandos(gerenciadorEmails);

            gerenciadorComandos.ExecutarComandosConsole();
        }
    }
}
