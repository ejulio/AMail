using AMail.Dominio;
using System;
using System.Collections.Generic;

namespace AMail.Aplicacao.Comandos
{
    public class GerenciadorComandos
    {
        private IDictionary<string, IComando> comandos; 

        public GerenciadorComandos(IGerenciadorEmails gerenciadorEmails)
        {
            comandos = new Dictionary<string, IComando>
            {
                {"novo", new ComandoNovoEmail(gerenciadorEmails)},
                {"lista", new ComandoListarEmails(gerenciadorEmails)}
            };
        }

        public void ExecutarComandosConsole()
        {
            foreach (var comandoConsole in ProximoComando())
            {
                if (!comandos.ContainsKey(comandoConsole))
                    Console.WriteLine("Comando não suportado: {0}", comandoConsole);
                else
                    comandos[comandoConsole].Executar();
            }
        }

        private IEnumerable<string> ProximoComando()
        {
            while (true)
            {
                Console.WriteLine("Digite um comando (novo, lista):");
                yield return Console.ReadLine();
            }
        }
    }
}