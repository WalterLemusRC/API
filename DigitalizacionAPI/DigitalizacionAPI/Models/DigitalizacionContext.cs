using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Models;

public partial class DigitalizacionContext : DbContext
{
    public DigitalizacionContext()
    {
    }

    public DigitalizacionContext(DbContextOptions<DigitalizacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<BitacoraBackup> BitacoraBackups { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<DocumentosHistorico> DocumentosHistoricos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Etiqueta> Etiqueta { get; set; }

    public virtual DbSet<OrigenDocumento> OrigenDocumentos { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ida");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_modificacion");
            entity.Property(e => e.IdDocumento).HasColumnName("Id_documento");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Transaccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auditoria");
        });

        modelBuilder.Entity<BitacoraBackup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Idbb");

            entity.ToTable("Bitacora_backup");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.LogDeError)
                .IsUnicode(false)
                .HasColumnName("Log_de_error");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_archivo");
            entity.Property(e => e.Ruta)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Id");

            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_modificacion");
            entity.Property(e => e.IdEstado).HasColumnName("Id_estado");
            entity.Property(e => e.IdEtiqueta).HasColumnName("Id_etiqueta");
            entity.Property(e => e.IdOrigen).HasColumnName("Id_origen");
            entity.Property(e => e.IdTipo).HasColumnName("Id_tipo");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_archivo");
            entity.Property(e => e.Ruta)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documentos");

            entity.HasOne(d => d.IdEtiquetaNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdEtiqueta)
                .HasConstraintName("FK_etiqueta");

            entity.HasOne(d => d.IdOrigenNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdOrigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Origen_documentos");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tipos_documento");
        });

        modelBuilder.Entity<DocumentosHistorico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Idh");

            entity.ToTable("Documentos_historico");

            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_modificacion");
            entity.Property(e => e.IdEstado).HasColumnName("Id_estado");
            entity.Property(e => e.IdOrigen).HasColumnName("Id_origen");
            entity.Property(e => e.IdTipo).HasColumnName("Id_tipo");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_archivo");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.DocumentosHistoricos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documentos_historico");

            entity.HasOne(d => d.IdOrigenNavigation).WithMany(p => p.DocumentosHistoricos)
                .HasForeignKey(d => d.IdOrigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Origen_Documentosh");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.DocumentosHistoricos)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tipos_documentoh");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_estados");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Etiqueta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Etiquetas");
            entity.ToTable("Etiquetas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrigenDocumento>(entity =>
        {
            entity.ToTable("Origen_documentos");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tipos_documento");

            entity.ToTable("Tipos_documento");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Idu");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
