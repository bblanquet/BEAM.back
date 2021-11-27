using BEAM.back.Model;
using System.Collections.Generic;

namespace BEAM.back.Services
{
    public interface IScooterService
    {
        List<Scooter> GetAll();
        List<NearScooter> GetNear(double longitude, double latitude, double radius, int scooterCount);
        string Populate(int count);
        string Clear();
    }
}
