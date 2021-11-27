using BEAM.back.Model;
using System;

namespace BEAM.back.Utils
{
    public class LocationProvider : ILocationProvider
    {
        private const double SINGAPORE_LATITUDE = 1.3521;
        private const double SINGAPORE_LONGITUDE = 103.8198;

        public Point GetLocation()
        {
            var latitude = new Random().NextDouble() * 0.3 + SINGAPORE_LATITUDE;
            var longitude = new Random().NextDouble() * 0.3 + SINGAPORE_LONGITUDE;
            return new Point(latitude,longitude);
        }
    }
}
