using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MensajesAPI.Models
{
    public partial class Proyecto_mensajes_pwa_bdContext : DbContext
    {
        public Proyecto_mensajes_pwa_bdContext()
        {
        }

        public Proyecto_mensajes_pwa_bdContext(DbContextOptions<Proyecto_mensajes_pwa_bdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; } = null!;
        public virtual DbSet<AlumnoDocente> AlumnoDocente { get; set; } = null!;
        public virtual DbSet<AlumnoMensaje> AlumnoMensaje { get; set; } = null!;
        public virtual DbSet<Docente> Docente { get; set; } = null!;
        public virtual DbSet<DocenteEspecialidad> DocenteEspecialidad { get; set; } = null!;
        public virtual DbSet<DocenteGrupo> DocenteGrupo { get; set; } = null!;
        public virtual DbSet<Especialidad> Especialidad { get; set; } = null!;
        public virtual DbSet<EspecialidadMensaje> EspecialidadMensaje { get; set; } = null!;
        public virtual DbSet<Grupo> Grupo { get; set; } = null!;
        public virtual DbSet<GrupoMensaje> GrupoMensaje { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensaje { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("alumno");

                entity.HasIndex(e => e.FkIdEspecialidad, "FkIdEspecialidad_idx");

                entity.HasIndex(e => e.FkIdGrupo, "FkIdGrupo_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.NombreCompleto).HasMaxLength(100);

                entity.Property(e => e.NumeroControl).HasMaxLength(10);

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("FkIdEspecialidadAlumno");

                entity.HasOne(d => d.FkIdGrupoNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.FkIdGrupo)
                    .HasConstraintName("FkIdGrupoAlumno");
            });

            modelBuilder.Entity<AlumnoDocente>(entity =>
            {
                entity.ToTable("alumno_docente");

                entity.HasIndex(e => e.FkIdAlumno, "FkIdAlumnoDocente_idx");

                entity.HasIndex(e => e.FkIdDocente, "FkIdAlumno_Docente_Docente_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkIdAlumnoNavigation)
                    .WithMany(p => p.AlumnoDocente)
                    .HasForeignKey(d => d.FkIdAlumno)
                    .HasConstraintName("FkIdAlumno_Docente_Alumno");

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.AlumnoDocente)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("FkIdAlumno_Docente_Docente");
            });

            modelBuilder.Entity<AlumnoMensaje>(entity =>
            {
                entity.ToTable("alumno_mensaje");

                entity.HasIndex(e => e.FkIdAlumno, "FkIdAlumno_Mensaje_Alumno_idx");

                entity.HasIndex(e => e.FkIdMensaje, "FkIdAlumno_Mensaje_Mensaje_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkIdAlumnoNavigation)
                    .WithMany(p => p.AlumnoMensaje)
                    .HasForeignKey(d => d.FkIdAlumno)
                    .HasConstraintName("FkIdAlumno_Mensaje_Alumno");

                entity.HasOne(d => d.FkIdMensajeNavigation)
                    .WithMany(p => p.AlumnoMensaje)
                    .HasForeignKey(d => d.FkIdMensaje)
                    .HasConstraintName("FkIdAlumno_Mensaje_Mensaje");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.ToTable("docente");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.NombreCompleto).HasMaxLength(100);

                entity.Property(e => e.NumeroControl).HasMaxLength(10);
            });

            modelBuilder.Entity<DocenteEspecialidad>(entity =>
            {
                entity.ToTable("docente_especialidad");

                entity.HasIndex(e => e.FkIdDocente, "FkIdDocente_Especialidad_Docente_idx");

                entity.HasIndex(e => e.FkIdEspecialidad, "FkIdDocente_Especialidad_Especialidad_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.DocenteEspecialidad)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("FkIdDocente_Especialidad_Docente");

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.DocenteEspecialidad)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("FkIdDocente_Especialidad_Especialidad");
            });

            modelBuilder.Entity<DocenteGrupo>(entity =>
            {
                entity.ToTable("docente_grupo");

                entity.HasIndex(e => e.FkIdDocente, "FkIdDocente_Grupo_Docente_idx");

                entity.HasIndex(e => e.FkIdGrupo, "FkIdDocente_Grupo_Grupo_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.DocenteGrupo)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("FkIdDocente_Grupo_Docente");

                entity.HasOne(d => d.FkIdGrupoNavigation)
                    .WithMany(p => p.DocenteGrupo)
                    .HasForeignKey(d => d.FkIdGrupo)
                    .HasConstraintName("FkIdDocente_Grupo_Grupo");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("especialidad");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(60);
            });

            modelBuilder.Entity<EspecialidadMensaje>(entity =>
            {
                entity.ToTable("especialidad_mensaje");

                entity.HasIndex(e => e.FkIdEspecialidad, "FkIdEspecialidad_Mensaje_Especialidad_idx");

                entity.HasIndex(e => e.FkIdMensaje, "FkIdEspecialidad_Mensaje_Mensaje_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.EspecialidadMensaje)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("FkIdEspecialidad_Mensaje_Especialidad");

                entity.HasOne(d => d.FkIdMensajeNavigation)
                    .WithMany(p => p.EspecialidadMensaje)
                    .HasForeignKey(d => d.FkIdMensaje)
                    .HasConstraintName("FkIdEspecialidad_Mensaje_Mensaje");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.HasIndex(e => e.FkIdEspecialidad, "FkIdEspecialidad_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(20);

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("FkIdEspecialidad");
            });

            modelBuilder.Entity<GrupoMensaje>(entity =>
            {
                entity.ToTable("grupo_mensaje");

                entity.HasIndex(e => e.FkIdGrupo, "FkIdGrupo_Mensaje_Grupo_idx");

                entity.HasIndex(e => e.FkIdMensaje, "FkIdGrupo_Mensaje_Mensaje_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkIdGrupoNavigation)
                    .WithMany(p => p.GrupoMensaje)
                    .HasForeignKey(d => d.FkIdGrupo)
                    .HasConstraintName("FkIdGrupo_Mensaje_Grupo");

                entity.HasOne(d => d.FkIdMensajeNavigation)
                    .WithMany(p => p.GrupoMensaje)
                    .HasForeignKey(d => d.FkIdMensaje)
                    .HasConstraintName("FkIdGrupo_Mensaje_Mensaje");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.ToTable("mensaje");

                entity.HasIndex(e => e.FkIdDocente, "FkIdDocente_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Asunto).HasColumnType("text");

                entity.Property(e => e.Destinatarios).HasColumnType("text");

                entity.Property(e => e.Mensaje1)
                    .HasColumnType("text")
                    .HasColumnName("Mensaje");

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.Mensaje)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("FkIdDocente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
