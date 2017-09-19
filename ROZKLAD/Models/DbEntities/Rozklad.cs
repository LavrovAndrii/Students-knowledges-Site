using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROZKLAD.Models.DbEntities
{
    public class Rozklad
    {
        [Key]
        public int Id { get; set; }

        public int LessonId { get; set; }

        public string GroupId { get; set; }

        public string TeacherId { get; set; }


        public virtual ICollection<Lesson> Lessons { get; set; }
       
        public virtual ICollection<Subject> Subjects { get; set; } //ІД дисципліни
        
        public virtual ICollection<Group> Groups { get; set; }//ІД групи

        public virtual ICollection<Teacher> Teachers { get; set; }//ІД викладача
    }
}