using System.Collections.Generic;
using System.Linq;

namespace AMail.Dominio.Treinamento
{
    public class DadosTreinamento
    {
        public int QuantidadeClasses { get; private set; }

        public int[] Saidas
        {
            get { return saidas.ToArray(); }
        }
        public double[][] Entradas
        {
            get { return entradas.ToArray(); }
        }

        private LinkedList<int> saidas;
        private LinkedList<double[]> entradas; 

        public DadosTreinamento()
        {
            saidas = new LinkedList<int>();
            entradas = new LinkedList<double[]>();
            QuantidadeClasses = 0;
        }

        public void Adicionar(double[] caracteristicas, int classe)
        {
            entradas.AddFirst(caracteristicas);
            saidas.AddFirst(classe);
            QuantidadeClasses++;
        }
    }
}