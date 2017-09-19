using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROZKLAD.Models.DbEntities
{
    public class Ocinka
    {
        [Key]
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdLesson { get; set; }
        public int Mark { get; set; }


        public virtual Student Students { get; set; }

        public virtual Lesson Lessons { get; set; }
    }
}