using System.Collections.Generic;
using System.Linq;

namespace AMail.Dominio.Treinamento
{
    public class DadosTreinamento
    {
        public int QuantidadeClasses
        {
            get { return classes.Count; }
        }

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
        private readonly HashSet<int> classes; 

        public DadosTreinamento()
        {
            saidas = new LinkedList<int>();
            entradas = new LinkedList<double[]>();
            classes = new HashSet<int>();
        }

        public void Adicionar(double[] caracteristicas, int classe)
        {
            entradas.AddLast(caracteristicas);
            saidas.AddLast(classe);
            classes.Add(classe);
        }
    }
}