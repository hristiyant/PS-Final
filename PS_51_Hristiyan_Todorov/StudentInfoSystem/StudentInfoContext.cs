using System.Data.Entity;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
