using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROZKLAD.Models.DbEntities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Year { get; set; }
  
        public virtual ICollection<Student> Student { get; set; }
    }
}