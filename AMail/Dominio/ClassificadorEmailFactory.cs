using AMail.Dominio.Classificacao;
using AMail.Dominio.Treinamento;

namespace AMail.Dominio
{
    public class ClassificadorEmailFactory
    {
        public ClassificadorEmail Criar()
        {
            var svm = new Svm();
            var geradorCaracteristicas = new GeradorCaracteristicas();
            var geradorDadosTreinamento = new GeradorDadosTreinamento(geradorCaracteristicas, null);
            return new ClassificadorEmail(svm, geradorCaracteristicas, geradorDadosTreinamento);
        }
    }
}