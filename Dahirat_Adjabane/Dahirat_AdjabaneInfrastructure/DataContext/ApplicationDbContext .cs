using Dahirat_AdjabaneDomaine.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<Member, MemberRole, string>
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<CharityProject> CharityProjects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberId); // Définir Id comme clé primaire
            });


            modelBuilder.Entity<Donation>(entity =>
            {
                entity.HasKey(e => e.DonationId); // Définir Id comme clé primaire
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId); // Définir Id comme clé primaire
            });
            modelBuilder.Entity<CharityProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId); // Définir Id comme clé primaire
            });
            modelBuilder.Entity<CharityProject>()
          .Property(c => c.Budget)
          .HasColumnType("decimal(18,2)"); // Spécifie la précision et l'échelle

            modelBuilder.Entity<Donation>()
                .Property(d => d.Amount)
                .HasColumnType("decimal(18,2)"); // Spécifie la précision et l'échelle
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Donation>()
           .HasKey(cp => cp.ProjectId);  // Définir ProjectId comme clé primaire
            modelBuilder.Entity<Donation>()
          .HasKey(cp => cp.EventId);  // Définir ProjectId comme clé primaire
            modelBuilder.Entity<Donation>()
       .HasKey(cp => cp.MemberId);  // Définir ProjectId comme clé primaire
            modelBuilder.Entity<CharityProject>()
          .HasKey(cp => cp.ProjectId);  // Définir ProjectId comme clé primaire
            base.OnModelCreating(modelBuilder);

        }
    }
    }
