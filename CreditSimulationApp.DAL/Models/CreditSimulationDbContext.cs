using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CreditSimulationApp.DAL.Models;

public partial class CreditSimulationDbContext : DbContext
{
    public CreditSimulationDbContext()
    {
    }

    public CreditSimulationDbContext(DbContextOptions<CreditSimulationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=CreditSimulationDB;User Id=UserCreditSimulation;Password=123456;Encrypt=Yes;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07A7DA4904");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Creditos__3214EC0793F710D2");

            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TasaInteres).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Creditos__Client__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
