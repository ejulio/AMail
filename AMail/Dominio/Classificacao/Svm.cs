using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math;
using Accord.Statistics.Kernels;
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
            var kernel = new Linear(1);
            var quantidadeCaracteristicas = dadosTreinamento.Entradas[0].Length;
            var quantidadeClasses = dadosTreinamento.Saidas.Distinct().Length;
            svm = new MulticlassSupportVectorMachine(quantidadeCaracteristicas, kernel, quantidadeClasses);

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