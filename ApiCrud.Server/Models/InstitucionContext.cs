using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Server.Models;

public partial class InstitucionContext : DbContext
{
    public InstitucionContext()
    {
    }

    public InstitucionContext(DbContextOptions<InstitucionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnoCurso> AlumnoCursos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<RecuperarContra> RecuperarContras { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumnos__43FBBAC788E23FFB");

            entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");
            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlumnoCurso>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoCurso).HasName("PK__Alumno_C__0B303366E5B4F0A1");

            entity.ToTable("Alumno_Curso");

            entity.Property(e => e.IdAlumnoCurso).HasColumnName("idAlumno_curso");
            entity.Property(e => e.Año).HasColumnType("datetime");
            entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");
            entity.Property(e => e.IdCurso).HasColumnName("idCurso");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnoCursos)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__Alumno_Cu__idAlu__3D5E1FD2");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AlumnoCursos)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Alumno_Cu__idCur__3E52440B");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Cursos__8551ED0586EB5F1B");

            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Temario)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecuperarContra>(entity =>
        {
            entity.HasKey(e => e.IdRcontra).HasName("PK__Recupera__17E48EFED32870A4");

            entity.ToTable("RecuperarContra");

            entity.Property(e => e.IdRcontra).HasColumnName("idRContra");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Token)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RecuperarContras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Recuperar__idUsu__412EB0B6");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76EDAC32C4");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A662391EC2");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contra)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contra");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol).HasName("PK__Usuario___50B0920754DE9933");

            entity.ToTable("Usuario_Rol");

            entity.Property(e => e.IdUsuarioRol).HasColumnName("idUsuarioRol");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario_R__rol_i__5FB337D6");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario_R__usuar__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
