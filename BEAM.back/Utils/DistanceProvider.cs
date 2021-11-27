using BEAM.back.Model;
using System;

namespace BEAM.back.Utils
{
    public class DistanceProvider : IDistanceProvider
    {
        private const double PIx = 3.141592653589793;
        private const double RADIUS = 6378.16;

        public double GetDistance(Point a, Point b)
        {
            var dlon = ToRadians(b.Longitude - a.Longitude);
            var dlat = ToRadians(b.Latitude - a.Latitude);

            var angle = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) 
                + Math.Cos(ToRadians(a.Latitude)) * Math.Cos(ToRadians(b.Latitude)) 
                * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            
            angle = 2 * Math.Atan2(Math.Sqrt(angle), Math.Sqrt(1 - angle));
            
            return angle * RADIUS * 1000;
        }

        private static double ToRadians(double x)
        {
            return x * PIx / 180;
        }
    }
}
