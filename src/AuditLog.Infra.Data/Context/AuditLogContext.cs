using AuditLog.Domain.Entities;
using AuditLog.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuditLog.Infra.Data.Context
{
    public class AuditLogContext : DbContext
    {
        #region PARAMETERS
        public IConfiguration Configuration { get; }
        #endregion

        #region DB SETS
        public DbSet<Location> Location { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Application> Application { get; set; }
        #endregion

        #region CONSTRUCTOR
        public AuditLogContext(DbContextOptions<AuditLogContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        #endregion

        #region ON MODEL CREATING
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new RequestMap());
            modelBuilder.ApplyConfiguration(new ResponseMap());
            modelBuilder.ApplyConfiguration(new ApplicationMap());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region ON CONFIGURING
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AuditLogConnection"));
        }
        #endregion
    }
}
