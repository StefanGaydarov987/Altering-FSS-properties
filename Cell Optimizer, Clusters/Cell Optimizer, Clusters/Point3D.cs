using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Optimizer__Clusters
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = EnforceRange(x);
            Y = EnforceRange(y);
            Z = EnforceRange(z);
        }

        private double EnforceRange(double value)
        {
            return Math.Max(0, Math.Min(2, value));
        }
    }
}
