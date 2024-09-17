using System;
using System.Collections.Generic;
using DynForms.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DynForms.Server.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Field> TblFields { get; set; }

    public virtual DbSet<Form> TblForms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tbl_Fiel__3214EC077A0E4AA2");

            entity.ToTable("Tbl_Field");

            entity.Property(e => e.Label)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Width).HasDefaultValue((short)4);

            entity.HasOne(d => d.Form).WithMany(p => p.TblFields)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Tbl_Field__FormI__4AB81AF0");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tbl_Form__3214EC071B1254A6");

            entity.ToTable("Tbl_Form");

            entity.Property(e => e.DisplayName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
