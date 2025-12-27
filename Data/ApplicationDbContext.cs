using Mahara.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mahara.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<UserSkill> UserSkills { get; set; } = null!;
        public DbSet<ExchangeRequest> ExchangeRequests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure ExchangeRequest relationships
            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.Sender)
                .WithMany(u => u.SentExchangeRequests)
                .HasForeignKey(e => e.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.Receiver)
                .WithMany(u => u.ReceivedExchangeRequests)
                .HasForeignKey(e => e.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.SkillOffered)
                .WithMany()
                .HasForeignKey(e => e.SkillOfferedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.SkillRequested)
                .WithMany()
                .HasForeignKey(e => e.SkillRequestedId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure UserSkill relationships
            builder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(us => us.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
