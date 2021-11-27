using BEAM.back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEAM.back.Utils
{
    public static class ScooterExtensions
    {
        public static Point GetLocation(this Scooter val)
        {
            return new Point(val.Latitude, val.Longitude);
        }
    }
}
