using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CJ.Models;

namespace CJ.Data;

public partial class CJDBContext : DbContext
{
    public CJDBContext()
    {
    }

    public CJDBContext(DbContextOptions<CJDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Brugere> Brugeres { get; set; }

    public virtual DbSet<Kategorier> Kategoriers { get; set; }

    public virtual DbSet<Kommentarer> Kommentarers { get; set; }

    public virtual DbSet<Prioriteter> Prioriteters { get; set; }

    public virtual DbSet<Roller> Rollers { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Vedhæftninger> Vedhæftningers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Brugere>(entity =>
        {
            entity.HasKey(e => e.BrugerId).HasName("PK__Brugere__6FA2FB307AD78DFE");

            entity.HasOne(d => d.Rolle).WithMany(p => p.Brugeres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Brugere__RolleID__6A30C649");
        });

        modelBuilder.Entity<Kategorier>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC92DEA6A9C4");

            entity.Property(e => e.KategoriId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Kommentarer>(entity =>
        {
            entity.HasKey(e => e.KommentarId).HasName("PK__Kommenta__A7D70671AAEDFDC9");

            entity.Property(e => e.Tid).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ForfatterNavigation).WithMany(p => p.Kommentarers).HasConstraintName("FK__Kommentar__Forfa__7D439ABD");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Kommentarers).HasConstraintName("FK__Kommentar__Ticke__7C4F7684");
        });

        modelBuilder.Entity<Prioriteter>(entity =>
        {
            entity.HasKey(e => e.PrioritetId).HasName("PK__Priorite__1B0C067AC3A4FCF9");

            entity.Property(e => e.PrioritetId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Roller>(entity =>
        {
            entity.HasKey(e => e.RolleId).HasName("PK__Roller__362255C70A7C15F1");

            entity.Property(e => e.BrugerAdmFull).HasDefaultValue(false);
            entity.Property(e => e.BrugerAdmRo).HasDefaultValue(false);
            entity.Property(e => e.DatabaseFull).HasDefaultValue(false);
            entity.Property(e => e.DatabaseRo).HasDefaultValue(false);
            entity.Property(e => e.TicketBruger).HasDefaultValue(true);
            entity.Property(e => e.TicketFull).HasDefaultValue(false);
            entity.Property(e => e.TicketRo).HasDefaultValue(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2043237AAF8C");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC62798477AE1");

            entity.Property(e => e.Oprettelsestid).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SidsteOpdatering).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Bruger).WithMany(p => p.TicketBrugers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__BrugerI__74AE54BC");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__Kategor__778AC167");

            entity.HasOne(d => d.PrioritetNavigation).WithMany(p => p.Tickets).HasConstraintName("FK__Tickets__Priorit__787EE5A0");

            entity.HasOne(d => d.Status).WithMany(p => p.Tickets).HasConstraintName("FK__Tickets__StatusI__76969D2E");

            entity.HasOne(d => d.Supporter).WithMany(p => p.TicketSupporters).HasConstraintName("FK__Tickets__Support__75A278F5");
        });

        modelBuilder.Entity<Vedhæftninger>(entity =>
        {
            entity.HasKey(e => e.VedhæftningId).HasName("PK__Vedhæftn__F821C2C4A4829B5C");

            entity.HasOne(d => d.Kommentar).WithMany(p => p.Vedhæftningers).HasConstraintName("FK__Vedhæftni__Komme__00200768");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
