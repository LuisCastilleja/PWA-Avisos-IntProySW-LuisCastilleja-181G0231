
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MensajesAPI.Models
{
    public partial class itesrcne_pwa_mensajes_181g0231_bdContext : DbContext
    {
        public itesrcne_pwa_mensajes_181g0231_bdContext()
        {
        }

        public itesrcne_pwa_mensajes_181g0231_bdContext(DbContextOptions<itesrcne_pwa_mensajes_181g0231_bdContext> options)
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
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("alumno");

                entity.HasIndex(e => e.FkIdEspecialidad, "FkIdEspecialidad_idx");

                entity.HasIndex(e => e.FkIdGrupo, "FkIdGrupoAlumno_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.FkIdEspecialidad).HasColumnType("int(11)");

                entity.Property(e => e.FkIdGrupo).HasColumnType("int(11)");

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

                entity.HasIndex(e => e.FkIdAlumno, "Fk_alumno_docente_alumno_idx");

                entity.HasIndex(e => e.FkIdDocente, "Fk_alumno_docente_docente_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdAlumno).HasColumnType("int(11)");

                entity.Property(e => e.FkIdDocente).HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdAlumnoNavigation)
                    .WithMany(p => p.AlumnoDocente)
                    .HasForeignKey(d => d.FkIdAlumno)
                    .HasConstraintName("Fk_alumno_docente_alumno");

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.AlumnoDocente)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("Fk_alumno_docente_docente");
            });

            modelBuilder.Entity<AlumnoMensaje>(entity =>
            {
                entity.ToTable("alumno_mensaje");

                entity.HasIndex(e => e.FkIdAlumno, "Fk_alumno_mensaje_alumno_idx");

                entity.HasIndex(e => e.FkIdMensaje, "Fk_alumno_mensaje_mensaje_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdAlumno).HasColumnType("int(11)");

                entity.Property(e => e.FkIdMensaje).HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdAlumnoNavigation)
                    .WithMany(p => p.AlumnoMensaje)
                    .HasForeignKey(d => d.FkIdAlumno)
                    .HasConstraintName("Fk_alumno_mensaje_alumno");

                entity.HasOne(d => d.FkIdMensajeNavigation)
                    .WithMany(p => p.AlumnoMensaje)
                    .HasForeignKey(d => d.FkIdMensaje)
                    .HasConstraintName("Fk_alumno_mensaje_mensaje");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.ToTable("docente");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.NombreCompleto).HasMaxLength(100);

                entity.Property(e => e.NumeroControl).HasMaxLength(10);
            });

            modelBuilder.Entity<DocenteEspecialidad>(entity =>
            {
                entity.ToTable("docente_especialidad");

                entity.HasIndex(e => e.FkIdDocente, "Fk_docente_especialidad_docente_idx");

                entity.HasIndex(e => e.FkIdEspecialidad, "Fk_docente_especialidad_especialidad_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdDocente).HasColumnType("int(11)");

                entity.Property(e => e.FkIdEspecialidad).HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.DocenteEspecialidad)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("Fk_docente_especialidad_docente");

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.DocenteEspecialidad)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("Fk_docente_especialidad_especialidad");
            });

            modelBuilder.Entity<DocenteGrupo>(entity =>
            {
                entity.ToTable("docente_grupo");

                entity.HasIndex(e => e.FkIdDocente, "Fk_docente_grupo_docente_idx");

                entity.HasIndex(e => e.FkIdGrupo, "Fk_docente_grupo_grupo_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdDocente).HasColumnType("int(11)");

                entity.Property(e => e.FkIdGrupo).HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.DocenteGrupo)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("Fk_docente_grupo_docente");

                entity.HasOne(d => d.FkIdGrupoNavigation)
                    .WithMany(p => p.DocenteGrupo)
                    .HasForeignKey(d => d.FkIdGrupo)
                    .HasConstraintName("Fk_docente_grupo_grupo");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("especialidad");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(60);
            });

            modelBuilder.Entity<EspecialidadMensaje>(entity =>
            {
                entity.ToTable("especialidad_mensaje");

                entity.HasIndex(e => e.FkIdEspecialidad, "Fk_especialidad_mensaje_especialidad_idx");

                entity.HasIndex(e => e.FkIdMensaje, "Fk_especialidad_mensaje_mensaje_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdEspecialidad).HasColumnType("int(11)");

                entity.Property(e => e.FkIdMensaje).HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.EspecialidadMensaje)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("Fk_especialidad_mensaje_especialidad");

                entity.HasOne(d => d.FkIdMensajeNavigation)
                    .WithMany(p => p.EspecialidadMensaje)
                    .HasForeignKey(d => d.FkIdMensaje)
                    .HasConstraintName("Fk_especialidad_mensaje_mensaje");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.HasIndex(e => e.FkIdEspecialidad, "FkIdEspecialidad_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdEspecialidad).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(20);

                entity.HasOne(d => d.FkIdEspecialidadNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.FkIdEspecialidad)
                    .HasConstraintName("FkEspecialidadGrupo");
            });

            modelBuilder.Entity<GrupoMensaje>(entity =>
            {
                entity.ToTable("grupo_mensaje");

                entity.HasIndex(e => e.FkIdGrupo, "Fk_grupo_mensaje_grupo_idx");

                entity.HasIndex(e => e.FkIdMensaje, "Fk_grupo_mensaje_mensaje_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FkIdGrupo).HasColumnType("int(11)");

                entity.Property(e => e.FkIdMensaje).HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdGrupoNavigation)
                    .WithMany(p => p.GrupoMensaje)
                    .HasForeignKey(d => d.FkIdGrupo)
                    .HasConstraintName("Fk_grupo_mensaje_grupo");

                entity.HasOne(d => d.FkIdMensajeNavigation)
                    .WithMany(p => p.GrupoMensaje)
                    .HasForeignKey(d => d.FkIdMensaje)
                    .HasConstraintName("Fk_grupo_mensaje_mensaje");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.ToTable("mensaje");

                entity.HasIndex(e => e.FkIdDocente, "FkIdDocente_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Asunto).HasColumnType("text");

                entity.Property(e => e.Destinatarios).HasColumnType("text");

                entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

                entity.Property(e => e.FkIdDocente).HasColumnType("int(11)");

                entity.Property(e => e.MensajeEnviado).HasColumnType("text");

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
