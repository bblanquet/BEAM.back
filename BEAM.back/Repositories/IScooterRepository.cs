using BEAM.back.Model;
using System.Collections.Generic;

namespace BEAM.back.Repositories
{
    public interface IScooterRepository
    {
        public List<Scooter> GetAll();
        public int GetCount();
        public void Save(IEnumerable<Scooter> scooters);
        public void Clear();
    }
}
