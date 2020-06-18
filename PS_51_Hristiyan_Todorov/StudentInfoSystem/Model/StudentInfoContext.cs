using System.Data.Entity;

namespace StudentInfoSystem.Model
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
