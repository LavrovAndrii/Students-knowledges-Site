using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROZKLAD.Models.DbEntities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string NameSubject { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

}
}