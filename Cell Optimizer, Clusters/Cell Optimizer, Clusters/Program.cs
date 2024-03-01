using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Optimizer__Clusters
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting Monte Carlo optimization...");

            MonteCarloOptimizer optimizer = new MonteCarloOptimizer();
            (Point3D A, Point3D B, Point3D C, Point3D D) bestPoints = optimizer.OptimizeEnergy();

            Console.WriteLine("Monte Carlo optimization completed.");
        }
    }
}
