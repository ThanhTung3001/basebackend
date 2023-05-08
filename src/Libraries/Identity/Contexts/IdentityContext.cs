using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Contexts
{
    public class IdentityContext
    : IdentityDbContext<
        ApplicationUser, ApplicationRole, int,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        public DbSet<ApplicationMenu> ApplicationMenus { get; set; }
        public DbSet<ApplicationMenuRole> ApplicationMenuRole { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationMenuRole>().HasKey(sc => new { sc.MenuId, sc.RoleId });
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.HasMany<ApplicationMenuRole>(e => e.MenuRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(e => e.RoleId);
            });

            builder.Entity<ApplicationMenu>(entity =>
            {
                entity.ToTable(name: "Menu");
                entity.HasMany<ApplicationMenuRole>(e => e.MenuRoles)
                    .WithOne(e => e.Menu)
                    .HasForeignKey(e => e.MenuId);
                entity.HasMany(x => x.Children)
                    .WithOne(x => x.Parent)
                    .HasForeignKey(x => x.ParrentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                entity.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                entity.ToTable("UserRoles");


            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
