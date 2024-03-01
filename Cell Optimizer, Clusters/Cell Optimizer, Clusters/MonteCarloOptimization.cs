using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace Cell_Optimizer__Clusters
{
    public class MonteCarloOptimizer
    {
        private const int Iterations = 10000000;

        public (Point3D A, Point3D B, Point3D C, Point3D D) OptimizeEnergy()
        {
            Point3D bestA = new Point3D(0, 0, 0);  // Exactly (0, 0, 0) for A
            Point3D bestB = new Point3D(0, 0, 0);
            Point3D bestC = new Point3D(0, 0, 0);
            Point3D bestD = new Point3D(0, 0, 0);
            double bestEnergy = double.MaxValue;

            EnergyCalculator energyCalculator = new EnergyCalculator();
            Random random = new Random();

            for (int i = 0; i < Iterations; i++)
            {
                Point3D a = new Point3D(0, 0, 0);  // Exactly (0, 0, 0) for A
                Point3D b = new Point3D(1, 0, 0);
                Point3D c = new Point3D(2, 0, 0);
                Point3D d = new Point3D(1, 0, 0);

                double energy = energyCalculator.CalculateEnergy(a, b, c, d);

                if (energy < bestEnergy)
                {
                    bestEnergy = energy;
                    bestA = a;
                    bestB = b;
                    bestC = c;
                    bestD = d;
                }

                // Checkpoint at every 1/100 of the iterations
                if ((i + 1) % (Iterations / 100) == 0)
                {
                    Console.WriteLine("Checkpoint: Iteration {0}/{1}", i + 1, Iterations);
                    Console.WriteLine("Best energy so far: {0}", bestEnergy);
                    Console.WriteLine("------------------------------------------");
                }
            }

            Console.WriteLine("Best points found:");
            Console.WriteLine("A({0}, {1}, {2})", bestA.X, bestA.Y, bestA.Z);
            Console.WriteLine("B({0}, {1}, {2})", bestB.X, bestB.Y, bestB.Z);
            Console.WriteLine("C({0}, {1}, {2})", bestC.X, bestC.Y, bestC.Z);
            Console.WriteLine("D({0}, {1}, {2})", bestD.X, bestD.Y, bestD.Z);
            Console.WriteLine("Energy: {0}", bestEnergy);

            return (bestA, bestB, bestC, bestD);
        }

        private double EnforceRange(double value)
        {
            return Math.Max(0, Math.Min(2, value));
        }
    }
}
