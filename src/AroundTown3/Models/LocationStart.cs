using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AroundTown3.Models
{
    [Table("LocationStarts")]
    public class LocationStart
    {
        [Key]
        public int LocationId { get; set; }

        public string LocationName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public virtual Route Route { get; set; }
    }
}
