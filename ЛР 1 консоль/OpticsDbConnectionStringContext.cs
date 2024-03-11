using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server;

public partial class OpticsDbConnectionStringContext : DbContext
{
    public OpticsDbConnectionStringContext()
    {
    }

    public OpticsDbConnectionStringContext(DbContextOptions<OpticsDbConnectionStringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Optic> Optics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OpticsDbConnectionString;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.Model).IsRequired();
            entity.Property(e => e.ProductVersion)
                .IsRequired()
                .HasMaxLength(32);
        });

        modelBuilder.Entity<Optic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Optics");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FrameMaterial).HasColumnName("Frame_Material");
            entity.Property(e => e.InInstallments).HasColumnName("In_Installments");
            entity.Property(e => e.LeftLens).HasColumnName("Left_Lens");
            entity.Property(e => e.RightLens).HasColumnName("Right_Lens");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
