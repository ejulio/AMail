
using AMail.Dominio.Caracteristicas;
using AMail.Dominio.Entidades;
using AMail.Util.Colecoes;

namespace AMail.Dominio.Treinamento
{
    public class GeradorDadosTreinamento : IGeradorDadosTreinamento
    {
        private readonly IGeradorCaracteristicas geradorCaracteristicas;
        private readonly IColecaoChaveValor<Categoria, int> colecaoChaveValor;

        public GeradorDadosTreinamento(IGeradorCaracteristicas geradorCaracteristicas, IColecaoChaveValor<Categoria, int> colecaoChaveValor)
        {
            this.geradorCaracteristicas = geradorCaracteristicas;
            this.colecaoChaveValor = colecaoChaveValor;
        }

        public DadosTreinamento Extrair(EmailRecebido[] emailsRecebidos)
        {
            var dadosTreinamento = new DadosTreinamento();
            foreach (var emailRecebido in emailsRecebidos)
            {
                var caracteristicas = geradorCaracteristicas.Extrair(emailRecebido);
                var classe = colecaoChaveValor.ObterValor(emailRecebido.Categoria);
                dadosTreinamento.Adicionar(caracteristicas, classe);
            }

            return dadosTreinamento;
        }

        public Categoria ObterCategoria(int classe)
        {
            return colecaoChaveValor.ObterChave(classe);
        }
    }
}