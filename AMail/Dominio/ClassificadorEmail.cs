using AMail.Dominio.Caracteristicas;
using AMail.Dominio.Classificacao;
using AMail.Dominio.Entidades;
using AMail.Dominio.Treinamento;

namespace AMail.Dominio
{
    public class ClassificadorEmail : IClassificadorEmail
    {
        private readonly IAlgoritmoClassificacao algoritmoClassificacao;
        private readonly IGeradorCaracteristicas geradorCaracteristicas;
        private readonly IGeradorDadosTreinamento geradorDadosTreinamento;

        public ClassificadorEmail(IAlgoritmoClassificacao algoritmoClassificacao, IGeradorCaracteristicas geradorCaracteristicas, IGeradorDadosTreinamento geradorDadosTreinamento)
        {
            this.algoritmoClassificacao = algoritmoClassificacao;
            this.geradorCaracteristicas = geradorCaracteristicas;
            this.geradorDadosTreinamento = geradorDadosTreinamento;
        }

        public void Treinar(EmailRecebido[] emailsRecebidos)
        {
            var dadosTreinamento = geradorDadosTreinamento.Extrair(emailsRecebidos);
            algoritmoClassificacao.Treinar(dadosTreinamento);
        }

        public Categoria Classificar(EmailRecebido email)
        {
            var caracteristicas = geradorCaracteristicas.Extrair(email);
            var classe = algoritmoClassificacao.Classificar(caracteristicas);
            return geradorDadosTreinamento.ObterCategoria(classe);
        }
    }
}