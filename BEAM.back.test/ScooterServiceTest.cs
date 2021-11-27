using BEAM.back.Services;
using BEAM.back.test.Mocks;
using BEAM.back.Utils;
using NUnit.Framework;
using System.Linq;

namespace BEAM.back.test
{
    class ScooterServiceTest
    {
        private const double SINGAPORE_LATITUDE = 1.3521;
        private const double SINGAPORE_LONGITUDE = 103.8198;
        private const double RADIUS = 10000000; //10000km

        private IScooterService _scooterService;
        [SetUp]
        public void Setup() {
            this._scooterService = new ScooterService(
                new ScooterRepositoryMock(),
                new DistanceProvider(),
                new LocationProvider());
        }

        [Test]
        public void should_throw_an_exception_when_threshold_is_execeeded() {

            Assert.Throws<OutOfThresholdException>(() => { this._scooterService.Populate(410); });
        }

        [Test]
        public void should_retrieve_the_right_number_of_scooters()
        {
            var count = 10;
            this._scooterService.Populate(count);
            var scooters = this._scooterService.GetAll();

            Assert.That(scooters.Count == count, $"could not retrieve the right amount of scooters. result: {scooters.Count} expected: {count}");
        }

        [Test]
        public void should_clear_all_scooters()
        {
            var count = 10;
            this._scooterService.Populate(count);
            this._scooterService.Clear();
            var scooters = this._scooterService.GetAll();

            Assert.That(scooters.Count == 0, $"the list of scooters should be empty. result: {scooters.Count} expected: 0");
        }

        [Test]
        public void should_retrieve_the_closest_scooters()
        {
            var count = 50;
            var near_count = 5;
            this._scooterService.Populate(count);
            var nearScooters = this._scooterService.GetNear(SINGAPORE_LONGITUDE, SINGAPORE_LATITUDE, RADIUS, near_count);
            var nearScootersClone = nearScooters.ToList();

            Assert.That(nearScooters.Count == near_count, $"the list of scooters should be empty. result: {nearScooters.Count} expected: {near_count}");
            Assert.That(nearScooters.SequenceEqual(nearScootersClone.OrderBy(e => e.Distance)),"the list of scooters is not well sorted.");

        }
    }
}
