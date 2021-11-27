using BEAM.back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEAM.back.Utils
{
    public interface IDistanceProvider
    {
        double GetDistance(Point a, Point b);
    }
}
