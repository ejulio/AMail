using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using AMail.Dominio.Treinamento;
using System;

namespace AMail.Dominio.Classificacao
{
    public class Svm : IAlgoritmoClassificacao
    {
        private MulticlassSupportVectorMachine svm;

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
            svm = new MulticlassSupportVectorMachine(dadosTreinamento.Entradas[0].Length, dadosTreinamento.Saidas.Length);
            var learning = new MulticlassSupportVectorLearning(svm, dadosTreinamento.Entradas, dadosTreinamento.Saidas)
            {
                Algorithm = (machine, inputs, outputs, a, b) => new SequentialMinimalOptimization(machine, inputs, outputs)
                {
                    Complexity = 1.0
                }
            };

            learning.Run();
        }
    }
}