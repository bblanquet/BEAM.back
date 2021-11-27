using BEAM.back.Model;
using BEAM.back.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BEAM.back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScooterController
    {
        private readonly IScooterService _scooterService;
        private const int POPULATE_THRESHOLD = 100;

        public ScooterController(IScooterService scooterService) {
            this._scooterService = scooterService;
        }

        [HttpGet("all")]
        public IEnumerable<Scooter> Get() {
            return this._scooterService.GetAll();
        }

        [HttpGet("near")]
        public IEnumerable<NearScooter> Get(double longitude, double latitude, double radius, int scooterCount)
        {
            return this._scooterService.GetNear(longitude,latitude, radius, scooterCount);
        }

        [HttpPost("populate")]

        public string populate()
        {
            return this._scooterService.Populate(POPULATE_THRESHOLD);
        }

        [HttpDelete("clear")]

        public string Clear()
        {
            return this._scooterService.Clear();
        }
    }
}
