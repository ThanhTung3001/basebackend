using Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Models.DbEntities;
using Models.DbEntities.Attachments;
using Models.DbEntities.RouteBus;
using Models.DbEntities.Customer;

namespace Data.Contexts
{
    public class ApplicationDbContext : DbContext, IDbContext
    {

        public DbSet<Route> Routes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<RouteVehicle> RouteVehicles { get; set; }
        public DbSet<RouteSchedule> RouteSchedules { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterEntityMapping(modelBuilder);

            modelBuilder.Entity<Route>()
                .HasMany(r => r.RouteStops)
                .WithOne(rs => rs.Route)
                .HasForeignKey(rs => rs.RouteId);

            modelBuilder.Entity<Route>()
                .HasMany(r => r.RouteVehicles)
                .WithOne(rv => rv.Route)
                .HasForeignKey(rv => rv.RouteId);

            modelBuilder.Entity<Route>()
                .HasMany(r => r.RouteSchedules)
                .WithOne(rs => rs.Route)
                .HasForeignKey(rs => rs.RouteId);

            modelBuilder.Entity<RouteStop>()
                .HasOne(rs => rs.Route)
                .WithMany(r => r.RouteStops)
                .HasForeignKey(rs => rs.RouteId);

            modelBuilder.Entity<RouteStop>()
                .HasOne(rs => rs.Station)
                .WithMany(s => s.RouteStops)
                .HasForeignKey(rs => rs.StationId);

            modelBuilder.Entity<RouteStop>()
                .HasOne(rs => rs.Stop)
                .WithMany(s => s.RouteStops)
                .HasForeignKey(rs => rs.StopId);

            modelBuilder.Entity<RouteVehicle>()
                .HasOne(rv => rv.Route)
                .WithMany(r => r.RouteVehicles)
                .HasForeignKey(rv => rv.RouteId);

            modelBuilder.Entity<RouteVehicle>()
                .HasOne(rv => rv.Vehicle)
                .WithMany(v => v.RouteVehicles)
                .HasForeignKey(rv => rv.VehicleId);

            modelBuilder.Entity<RouteSchedule>()
                .HasOne(rs => rs.Route)
                .WithMany(r => r.RouteSchedules)
                .HasForeignKey(rs => rs.RouteId);
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.OrganizationUsers)
                .WithOne(ou => ou.Organization)
                .HasForeignKey(ou => ou.OrganizationId);


            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Vehicles)
                .WithOne(v => v.Organization)
                .HasForeignKey(v => v.OrganizationId);
            base.OnModelCreating(modelBuilder);
        }

        public void RegisterEntityMapping(ModelBuilder modelBuilder)
        {
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false) &&
                (type.BaseType.GetGenericTypeDefinition() == typeof(MappingEntityTypeConfiguration<>))
            );
            foreach (var item in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(item);
                configuration.ApplyConfiguration(modelBuilder);
            }
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }
        public void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e => (
                e.State == EntityState.Added || e.State == EntityState.Modified));
            // var username = HttpContext.User.Identity.Name;
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreateUTC = DateTime.UtcNow;
                    //  ((BaseEntity)entry.Entity).CreateBy = "example_user"; // thay bằng tên người dùng thực tế
                }
                else if (entry.State == EntityState.Modified)
                {
                    ((BaseEntity)entry.Entity).UpdateTime = DateTime.UtcNow;
                    //   ((BaseEntity)entry.Entity).UpdateBy = "example_user"; 
                }
            }
        }
    }
}
