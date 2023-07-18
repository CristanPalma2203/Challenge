using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Models;

public partial class PruebaContext : DbContext
{
    public PruebaContext()
    {
    }

    public PruebaContext(DbContextOptions<PruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<DepartmentsCompany> DepartmentsCompanies { get; set; }
    public virtual DbSet<Binnacle> Binnacles { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //    => optionsBuilder.UseSqlServer("Data Source=3.228.164.208;Initial Catalog=Prueba;Persist Security Info=True;User ID=sa;Password=SapiAdmin2020; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC072BFFEEC2");

            entity.ToTable("Company");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
