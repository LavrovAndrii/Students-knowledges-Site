using System.Data.Entity;

namespace ROZKLAD.Models.DbEntities
{
    public class DatabaseContext: System.Data.Entity.DbContext
    {
        public DatabaseContext()
            :base("ROZKLADConection")
        {
            
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Ocinka> Ocinkas { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Day> Days { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
 

            modelBuilder.Entity<Group>()
                .HasMany(a => a.Student)
                .WithRequired(a => a.Groups)
                .HasForeignKey(a => a.IdGroup);

            modelBuilder.Entity<Student>()
                .HasMany(a => a.Ocinkas)
                .WithRequired(a => a.Students)
                .HasForeignKey(a => a.IdStudent);

            modelBuilder.Entity<Subject>()
                .HasMany(a => a.Lessons)
                .WithRequired(a => a.Subjects)
                .HasForeignKey(a => a.IdSubject);

            modelBuilder.Entity<Day>()
                .HasMany(a => a.Lessons)
                .WithRequired(a => a.Days)
                .HasForeignKey(a => a.IdDay);

            modelBuilder.Entity<Teacher>()
                .HasMany(a => a.Lessons)
                .WithRequired(a => a.Teachers)
                .HasForeignKey(a => a.IdTeatcher);

            modelBuilder.Entity<Lesson>()
                .HasMany(a => a.Ocinkas)
                .WithRequired(a => a.Lessons)
                .HasForeignKey(a => a.IdLesson);

        }
    }
}