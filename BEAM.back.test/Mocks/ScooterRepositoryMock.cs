using BEAM.back.Model;
using BEAM.back.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BEAM.back.test.Mocks
{
    public class ScooterRepositoryMock : IScooterRepository
    {
        private readonly List<Scooter> _scooters = new List<Scooter>();
        public void Clear()
        {
            this._scooters.Clear();
        }

        public List<Scooter> GetAll()
        {
            //create a new instance of the list
            return this._scooters.ToList();
        }

        public int GetCount()
        {
            return this._scooters.Count;
        }

        public void Save(IEnumerable<Scooter> scooters)
        {
            this._scooters.AddRange(scooters);
        }
    }
}
