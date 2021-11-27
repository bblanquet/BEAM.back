using BEAM.back.Model;
using BEAM.back.Utils;
using NUnit.Framework;

namespace BEAM.back.test
{
    public class DistanceProviderTest
    {
        private const double SINGAPORE_LATITUDE = 1.3521;
        private const double SINGAPORE_LONGITUDE = 103.8198;

        private IDistanceProvider _distanceProvider;

        [OneTimeSetUp]
        public void Setup() {
            this._distanceProvider = new DistanceProvider();
        }

        [TestCase(1.0521, 100.8198, 335551.7899535557)]
        [TestCase(1.6521, 102.8198, 116184.61697807196)]
        [TestCase(2.3521, 104.8198, 157387.98228561893)]
        public void should_get_the_correct_distance(double lat, double lon, double expected) {
            var a = new Point(SINGAPORE_LATITUDE, SINGAPORE_LONGITUDE);
            var b = new Point(lat, lon);

            var result = this._distanceProvider.GetDistance(a,b);

            Assert.That(result == expected, $"the distance is wronly calculated. result: {result} expected: {expected}");
        }
    }
}
