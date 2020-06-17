using System.Data.Entity;

namespace UserLogin
{
    class LoggerContext : DbContext
    {
        public DbSet<Logs> Logs { get; set; }

        public LoggerContext() : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
