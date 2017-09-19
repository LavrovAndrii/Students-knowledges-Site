using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROZKLAD.Models.DbEntities
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public int IdDay { get; set; }
        public int IdTeatcher { get; set; }
        public int IdSubject { get; set; }

        public virtual Day Days { get; set; }
        public virtual Teacher Teachers { get; set; }
        public virtual Subject Subjects { get; set; }


        public virtual ICollection<Ocinka> Ocinkas { get; set; }

    }
}