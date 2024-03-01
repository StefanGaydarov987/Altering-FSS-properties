using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Optimizer__Clusters
{
    public class EnergyCalculator
    {
        private const double Pi = 3.14159;

        public double CalculateEnergy(Point3D a, Point3D b, Point3D c, Point3D d)
        {
            double energy = 0;

            // Calculate v3(a) for angle DAB only
            energy += V3(AngleDAB(a, b, c));

            // Calculate v2(l) for distances AB, BC, CD, DA
            energy += V2(Distance(a, b)) + V2(Distance(b, c)) + V2(Distance(c, d)) + V2(Distance(d, a));

            return energy;
        }

        private double Distance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }

        private double AngleDAB(Point3D a, Point3D b, Point3D c)
        {
            double distAB = Distance(a, b);
            double distAC = Distance(a, c);
            double distBC = Distance(b, c);

            return Math.Acos((distAB * distAB + distAC * distAC - distBC * distBC) / (2 * distAB * distAC));
        }

        private double V2(double x)
        {
            if (x >= 1)
                return Math.Sqrt(2) * x * x - (7.0 / 4 + 3 / (2 * Math.Sqrt(2))) * x - 1 / (2 * Math.Sqrt(2)) + 3 / 4;
            else
                return 2 * x * x - 15 * x + 12;
        }

        private double V3(double x)
        {
            if (x >= 0 && x <= Pi / 2)
                return (4 / (2 * Pi - 1)) * x * x - 6 * x + 1.0 / 2 + 3 * Pi - Pi * Pi / (2 * Pi - 1);
            else
                return (2 * (Pi - 1) * x * x) / (3 * Pi * Pi) - x + (2 + Pi) / 3;
        }
    }


}
