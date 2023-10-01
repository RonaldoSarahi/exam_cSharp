using csharp_api.Data.EntityTypeConfiguration;
using csharp_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace csharp_api.Data
{
    public class ExamDbContext : DbContext
    {
        private IConfiguration configuration;
        public ExamDbContext(DbContextOptions<ExamDbContext> options , IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        //DBSET DE TABLAS
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CONGIGURACIONES DE TABLAS
            modelBuilder.ApplyConfiguration(new ArticulosConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigureSqlServer(optionsBuilder);
        }

        private void ConfigureSqlServer(DbContextOptionsBuilder options)
        {
            var connectionString = configuration.GetSection("Connection").Value;
            options.UseSqlServer(connectionString);
        }
    }
}
