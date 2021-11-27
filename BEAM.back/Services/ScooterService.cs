using BEAM.back.Model;
using BEAM.back.Repositories;
using BEAM.back.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BEAM.back.Services
{
    public class ScooterService : IScooterService
    {
        private const int SCOOTER_MAX = 400;

        private readonly IScooterRepository _repository;
        private readonly IDistanceProvider _distanceProvider;
        private readonly ILocationProvider _locationProvider;

        public ScooterService(IScooterRepository repository, IDistanceProvider distanceProvider, ILocationProvider locationProvider) {
            this._distanceProvider = distanceProvider;
            this._locationProvider = locationProvider;
            this._repository = repository;
        }

        public List<Scooter> GetAll() {
            return this._repository.GetAll();
        }

        public List<NearScooter> GetNear(double longitude, double latitude, double radius, int scooterCount)
        {
            var location = new Point(latitude,longitude);
            var result = new List<NearScooter>();
            var closeScooters = new Dictionary<Double, Scooter>();
            var scooters = this.GetAll();
            foreach (var scooter in scooters) {
                var distance = this._distanceProvider.GetDistance(location, scooter.GetLocation());
                if (distance < radius) {
                    closeScooters.Add(distance, scooter);
                }
            }
            var distances = closeScooters.Keys.ToList();
            distances.Sort();
            foreach(var dist in distances) {
                result.Add(new NearScooter
                {
                    Distance = dist,
                    Scooter = closeScooters[dist]
                });
            }

            return result.Take(scooterCount).ToList();
        }

        public string Populate(int count)
        {
            if (SCOOTER_MAX < this._repository.GetCount() + count) {
                throw new OutOfThresholdException("Db contains too many scooters.");
            }
            var newScooters = new List<Scooter>();
            var i = 0;
            while (i < count) {
                var point = this._locationProvider.GetLocation();
                var scooter = new Scooter { 
                    Latitude = point.Latitude,
                    Longitude = point.Longitude
                };
                newScooters.Add(scooter);
                i++;
            }

            this._repository.Save(newScooters);
            return "100 scooters were added.";
        }


        public string Clear()
        {
            var count = this._repository.GetCount();
            this._repository.Clear();
            return $"{count} scouters were deleted.";
        }
    }
}
