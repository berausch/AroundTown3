using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AroundTown3.Models
{
    [Table("Routes")]
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual LocationEnd LocationEnd { get; set; }
        public virtual LocationStart LocationStart { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Route(string name, int id = 0)
        {
            Name = name;
            Id = id;
        }

        public Route() { }

    }

    
}
