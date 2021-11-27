using BEAM.back.Model;
using BEAM.back.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAM.back.test
{
    class LocationProviderTest
    {
        private const double SINGAPORE_LATITUDE = 1.3521;
        private const double SINGAPORE_LONGITUDE = 103.8198;

        private ILocationProvider _locationProvider;

        [OneTimeSetUp]
        public void Setup()
        {
            this._locationProvider = new LocationProvider();
        }

        [Test]
        public void should_get_the_correct_distance()
        {
            var latitudeMax = SINGAPORE_LATITUDE + 0.3;
            var longitudeMax = SINGAPORE_LONGITUDE+ 0.3;

            var latitudeMin = SINGAPORE_LATITUDE;
            var longitudeMin = SINGAPORE_LONGITUDE;

            var loc = this._locationProvider.GetLocation();

            Assert.That(latitudeMin <= loc.Latitude && loc.Latitude <= latitudeMax,
                $"the latitude should be betwen {latitudeMin} and {latitudeMax}. result: {loc.Latitude}");

            Assert.That(longitudeMin <= loc.Longitude && loc.Longitude <= longitudeMax,
                $"the latitude should be betwen {longitudeMin} and {longitudeMax}. result: {loc.Longitude}");
        }
    }
}
