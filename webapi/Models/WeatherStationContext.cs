using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class WeatherStationContext : DbContext
{
    public WeatherStationContext()
    {
    }

    public WeatherStationContext(DbContextOptions<WeatherStationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<Lectura> Lecturas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sensore> Sensores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departamentos_pkey");

            entity.ToTable("departamentos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dispositivos_pkey");

            entity.ToTable("dispositivos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Latitud)
                .HasMaxLength(100)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasMaxLength(100)
                .HasColumnName("longitud");
        });

        modelBuilder.Entity<Lectura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lecturas_pkey");

            entity.ToTable("lecturas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasDefaultValueSql("CURRENT_TIME")
                .HasColumnName("hora");
            entity.Property(e => e.SensorId).HasColumnName("sensor_id");
            entity.Property(e => e.Valor)
                .HasPrecision(10, 2)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("municipios_pkey");

            entity.ToTable("municipios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .HasColumnName("codigo");
            entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permisos_pkey");

            entity.ToTable("permisos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Crear).HasColumnName("crear");
            entity.Property(e => e.Editar).HasColumnName("editar");
            entity.Property(e => e.Eliminar).HasColumnName("eliminar");
            entity.Property(e => e.Leer).HasColumnName("leer");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("personas_pkey");

            entity.ToTable("personas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .HasColumnName("direccion");
            entity.Property(e => e.MunicipioId).HasColumnName("municipio_id");
            entity.Property(e => e.Nit)
                .HasMaxLength(12)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");

        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermisoId).HasColumnName("permiso_id");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Sensore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sensores_pkey");

            entity.ToTable("sensores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.DispositivoId).HasColumnName("dispositivo_id");
            entity.Property(e => e.Referencia)
                .HasMaxLength(50)
                .HasColumnName("referencia");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(18)
                .HasColumnName("password");
            entity.Property(e => e.PersonaId).HasColumnName("persona_id");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Username)
                .HasMaxLength(18)
                .HasColumnName("username");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
