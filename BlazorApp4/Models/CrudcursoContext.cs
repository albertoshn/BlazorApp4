using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Models;

public partial class CrudcursoContext : DbContext
{
    public CrudcursoContext()
    {
    }

    public CrudcursoContext(DbContextOptions<CrudcursoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<mDepartamento> Departamentos { get; set; }

    public virtual DbSet<mUsuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<mDepartamento>(entity =>
        {
            entity.HasKey(e => e.Departamentoid).HasName("PK__DEPARTAM__05BBF765DF225AE6");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.Departamentoid).HasColumnName("DEPARTAMENTOID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<mUsuario>(entity =>
        {
            entity.HasKey(e => e.Usuarioid).HasName("PK__USUARIOS__87968D30AD84243E");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Usuarioid).HasColumnName("USUARIOID");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Departamento).HasColumnName("DEPARTAMENTO");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Sueldo).HasColumnName("SUELDO");

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Departamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIOS__DEPART__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
