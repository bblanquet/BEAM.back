using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEAM.back.Model
{
    [Table("scooter")]
    public class Scooter
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("latitude")]
        public Double Latitude { get; set; }
        [Column("longitude")]
        public Double Longitude { get; set; }
    }
}
