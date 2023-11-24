using Microsoft.EntityFrameworkCore;

namespace LOG_IOT_Service.Models_DbContext
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Tabelas do Banco
        public DbSet<DEVICE> DEVICE { get; set; }
        public DbSet<USER> USER { get; set; }
        public DbSet<LOG> LOG { get; set; }

        public DbContext()
        {
            //Construtor do DB_Context
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Connection String to SQL SERVER
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LOG_IOT_Service;Integrated Security=True;");
        }
    }

}

