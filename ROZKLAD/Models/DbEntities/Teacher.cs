using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROZKLAD.Models.DbEntities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string SureName { get; set; }
        public string Name { get; set; }
        public string Father { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

    }
}