using System.Collections.Generic;

namespace AMail.Dominio.Treinamento
{
    public class GeradorDadosTreinamento : IGeradorDadosTreinamento
    {
        private readonly IGeradorCaracteristicas geradorCaracteristicas;
        private IDictionary<string, int> identificadoresClasses;
        private int identificador;

        public GeradorDadosTreinamento(IGeradorCaracteristicas geradorCaracteristicas)
        {
            this.geradorCaracteristicas = geradorCaracteristicas;
            identificadoresClasses = new Dictionary<string, int>();
            identificador = -1;
        }

        public DadosTreinamento Extrair(EmailRecebido[] emailsRecebidos)
        {
            var dadosTreinamento = new DadosTreinamento();
            foreach (var emailRecebido in emailsRecebidos)
            {
                var caracteristicas = geradorCaracteristicas.Extrair(emailRecebido);
                var classe = ObterClasse(emailRecebido);
                dadosTreinamento.Adicionar(caracteristicas, classe);
            }

            return dadosTreinamento;
        }

        private int ObterClasse(EmailRecebido emailRecebido)
        {
            if (emailRecebido.Categoria.Descricao.ToLower() == "spam")
                return -1;

            return 1;
        }
    }
}