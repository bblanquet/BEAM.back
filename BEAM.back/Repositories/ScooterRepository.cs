using BEAM.back.Model;
using BEAM.back.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BEAM.back.Repositories
{
    public class ScooterRepository : DbContext, IScooterRepository
    {
        public DbSet<Scooter> Scooters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseNpgsql(DataAccessHelper.ConnectionString());

        public List<Scooter> GetAll()
        {
            return this.Scooters.ToList();
        }

        public int GetCount()
        {
            return this.Scooters.Count();
        }

        public void Save(IEnumerable<Scooter> scooters)
        {
            this.Scooters.AddRange(scooters);
            this.SaveChanges();
        }

        public void Clear()
        {
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE scooter");
            this.SaveChanges();
        }

    }
}
