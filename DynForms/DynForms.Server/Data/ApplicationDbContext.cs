using System;
using System.Collections.Generic;
using DynForms.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DynForms.Server.Data;

// Database First Approach
// Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=dyn_forms;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Field__3214EC07439F2F46");

            entity.ToTable("Field");

            entity.Property(e => e.Label)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Width).HasDefaultValue((short)4);

            entity.HasOne(d => d.Form).WithMany(p => p.Fields)
                .HasForeignKey(d => d.FormId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Field__FormId__5070F446");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Form__3214EC07C9B7B5AC");

            entity.ToTable("Form");

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
