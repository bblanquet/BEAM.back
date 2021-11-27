using System;

namespace BEAM.back.Model
{
    public class Point
    {
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }

        public Point(Double latitude, Double longitude) {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}
