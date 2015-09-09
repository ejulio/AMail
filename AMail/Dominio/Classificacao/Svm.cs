using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using AMail.Dominio.Treinamento;
using System;

namespace AMail.Dominio.Classificacao
{
    public class Svm : IAlgoritmoClassificacao
    {
        private SupportVectorMachine svm;

        public int Classificar(double[] caracteristicas)
        {
            if (svm == null)
                throw new InvalidOperationException("É preciso treinar o algoritmo antes de classificar.");

            double output;
            var classe = svm.Compute(caracteristicas, out output);
            return classe;
        }

        public void Treinar(DadosTreinamento dadosTreinamento)
        {
            svm = new SupportVectorMachine(dadosTreinamento.Entradas[0].Length);
            var smo = new SequentialMinimalOptimization(svm, dadosTreinamento.Entradas, dadosTreinamento.Saidas)
            {
                Complexity = 1.0
            };

            smo.Run();
        }
    }
}