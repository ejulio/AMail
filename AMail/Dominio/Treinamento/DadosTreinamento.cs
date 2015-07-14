using System.Collections.Generic;
using System.Linq;

namespace AMail.Dominio.Treinamento
{
    public class DadosTreinamento
    {
        public int[] Saidas
        {
            get { return saidas.ToArray(); }
        }
        public double[][] Entradas
        {
            get { return entradas.ToArray(); }
        }

        private readonly LinkedList<int> saidas;
        private readonly LinkedList<double[]> entradas;

        public DadosTreinamento()
        {
            saidas = new LinkedList<int>();
            entradas = new LinkedList<double[]>();
        }

        public void Adicionar(double[] caracteristicas, int classe)
        {
            entradas.AddLast(caracteristicas);
            saidas.AddLast(classe);
        }
    }
}