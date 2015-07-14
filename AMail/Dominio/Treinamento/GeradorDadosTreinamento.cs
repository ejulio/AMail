using System.Collections.Generic;

namespace AMail.Dominio.Treinamento
{
    public class GeradorDadosTreinamento
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
            if (identificadoresClasses.ContainsKey(emailRecebido.Categoria.Descricao))
                return identificadoresClasses[emailRecebido.Categoria.Descricao];

            identificador++;
            identificadoresClasses[emailRecebido.Categoria.Descricao] = identificador;
            return identificador;
        }
    }
}