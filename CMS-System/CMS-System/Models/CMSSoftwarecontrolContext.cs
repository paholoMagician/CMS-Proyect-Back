﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMS_System.Models
{
    public partial class CMSSoftwarecontrolContext : DbContext
    {
        public CMSSoftwarecontrolContext()
        {
        }

        public CMSSoftwarecontrolContext(DbContextOptions<CMSSoftwarecontrolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencia> Agencia { get; set; }
        public virtual DbSet<AsignModUser> AsignModUser { get; set; }
        public virtual DbSet<Asignacionmaquinaria> Asignacionmaquinaria { get; set; }
        public virtual DbSet<Asignacionprovincias> Asignacionprovincias { get; set; }
        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<FileControl> FileControl { get; set; }
        public virtual DbSet<Imgfile> Imgfile { get; set; }
        public virtual DbSet<Maquinaria> Maquinaria { get; set; }
        public virtual DbSet<MasterTable> MasterTable { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VersionCms> VersionCms { get; set; }
        public virtual DbSet<Versionamiento> Versionamiento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.HasKey(e => e.Codagencia)
                    .HasName("PK_agencia1_1");

                entity.ToTable("agencia");

                entity.Property(e => e.Codagencia)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("codagencia");

                entity.Property(e => e.CampoA).HasColumnName("campoA");

                entity.Property(e => e.CampoB)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("campoB");

                entity.Property(e => e.CodCanton)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codCanton")
                    .IsFixedLength();

                entity.Property(e => e.CodProv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codProv")
                    .IsFixedLength();

                entity.Property(e => e.Codcia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codcia");

                entity.Property(e => e.Codcliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codcliente");

                entity.Property(e => e.Codfrecuencia)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codfrecuencia");

                entity.Property(e => e.Codmachine)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codmachine");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Horarioatenciond)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("horarioatenciond");

                entity.Property(e => e.Horarioatenciondm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("horarioatenciondm");

                entity.Property(e => e.Horarioatencionh)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("horarioatencionh");

                entity.Property(e => e.Horarioatencionhm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("horarioatencionhm");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo")
                    .IsFixedLength();
            });

            modelBuilder.Entity<AsignModUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("asignModUser");

                entity.Property(e => e.CodCia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cod_cia");

                entity.Property(e => e.CodMod)
                    .HasMaxLength(5)
                    .HasColumnName("cod_mod");

                entity.Property(e => e.CodUser)
                    .HasMaxLength(30)
                    .HasColumnName("cod_user");

                entity.Property(e => e.OrderMod).HasColumnName("order_mod");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<Asignacionmaquinaria>(entity =>
            {
                entity.ToTable("asignacionmaquinaria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codagencia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codagencia");

                entity.Property(e => e.Codcia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codcia");

                entity.Property(e => e.Codcli)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codcli");

                entity.Property(e => e.Codmaquina)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codmaquina");

                entity.Property(e => e.Codusercrea)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codusercrea");

                entity.Property(e => e.Estadomaquin).HasColumnName("estadomaquin");

                entity.Property(e => e.Feccrea)
                    .HasColumnType("datetime")
                    .HasColumnName("feccrea");
            });

            modelBuilder.Entity<Asignacionprovincias>(entity =>
            {
                entity.ToTable("asignacionprovincias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codcanton)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codcanton")
                    .IsFixedLength();

                entity.Property(e => e.Codcia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codcia");

                entity.Property(e => e.Codmantenimiento)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codmantenimiento")
                    .IsFixedLength();

                entity.Property(e => e.Codprov)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codprov")
                    .IsFixedLength();

                entity.Property(e => e.Coduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("coduser");

                entity.Property(e => e.Codusermod)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("codusermod");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechainicio");

                entity.Property(e => e.Fechamod)
                    .HasColumnType("datetime")
                    .HasColumnName("fechamod");
            });

            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.HasKey(e => e.Codaudit);

                entity.ToTable("auditoria");

                entity.Property(e => e.Codaudit)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codaudit");

                entity.Property(e => e.Accion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("accion");

                entity.Property(e => e.Cod)
                    .HasMaxLength(10)
                    .HasColumnName("cod")
                    .IsFixedLength();

                entity.Property(e => e.Codmodulo).HasColumnName("codmodulo");

                entity.Property(e => e.Codusuario)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codusuario");

                entity.Property(e => e.Fecfinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fecfinal");

                entity.Property(e => e.Fecinteraccion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecinteraccion");

                entity.Property(e => e.Informacion)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("informacion");

                entity.Property(e => e.Ip)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ip");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new { e.Codcliente, e.Ruc })
                    .HasName("PK_cliente1_1");

                entity.ToTable("cliente");

                entity.Property(e => e.Codcliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codcliente");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ruc");

                entity.Property(e => e.Codcia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codcia");

                entity.Property(e => e.Coduser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("coduser");

                entity.Property(e => e.Correomantenimiento)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("correomantenimiento");

                entity.Property(e => e.Correopago)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("correopago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fechacontfinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fechacontfinal");

                entity.Property(e => e.Fechacontinicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechacontinicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreMantenimiento)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombreMantenimiento");

                entity.Property(e => e.NombrePago)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombrePago");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.Replegal)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("replegal");

                entity.Property(e => e.Telfclimanteni)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telfclimanteni");

                entity.Property(e => e.Telfpago)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telfpago");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Codcia);

                entity.ToTable("empresa");

                entity.Property(e => e.Codcia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codcia");

                entity.Property(e => e.Canton)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("canton");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("ruc");

                entity.Property(e => e.Telf1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telf1");

                entity.Property(e => e.Telf2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telf2");
            });

            modelBuilder.Entity<FileControl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coduser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("coduser");

                entity.Property(e => e.Fecrea)
                    .HasColumnType("datetime")
                    .HasColumnName("fecrea");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Imgfile>(entity =>
            {
                entity.ToTable("imgfile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codentidad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codentidad");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Urlruta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlruta");
            });

            modelBuilder.Entity<Maquinaria>(entity =>
            {
                entity.HasKey(e => e.Codmaquina);

                entity.ToTable("maquinaria");

                entity.Property(e => e.Codmaquina)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codmaquina");

                entity.Property(e => e.Codcia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codcia");

                entity.Property(e => e.Codigobp)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("codigobp");

                entity.Property(e => e.Codtipomaquina)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codtipomaquina")
                    .IsFixedLength();

                entity.Property(e => e.Codusercrea)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codusercrea");

                entity.Property(e => e.Feccrea)
                    .HasColumnType("datetime")
                    .HasColumnName("feccrea");

                entity.Property(e => e.Marca)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Ninventario)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ninventario");

                entity.Property(e => e.Nombremaquina)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombremaquina");

                entity.Property(e => e.Nserie)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nserie");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("observacion");
            });

            modelBuilder.Entity<MasterTable>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Campo1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("campo1")
                    .IsFixedLength();

                entity.Property(e => e.Campo2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("campo2")
                    .IsFixedLength();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo")
                    .IsFixedLength();

                entity.Property(e => e.Gestion)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gestion")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength();

                entity.Property(e => e.Grupo)
                    .HasMaxLength(70)
                    .HasColumnName("grupo");

                entity.Property(e => e.Lencod)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("lencod");

                entity.Property(e => e.Master)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("master")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .HasColumnName("nombre");

                entity.Property(e => e.Nomtag)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nomtag")
                    .HasDefaultValueSql("(' ')")
                    .IsFixedLength();

                entity.Property(e => e.Pideval).HasColumnName("pideval");

                entity.Property(e => e.Sgrupo)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("sgrupo")
                    .IsFixedLength();

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("valor")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Valor2)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("VALOR2");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("modulo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("icon");

                entity.Property(e => e.ModuleDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("moduleDescription");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("moduleName");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Coduser)
                    .HasName("PK_usuarios");

                entity.ToTable("usuario");

                entity.Property(e => e.Coduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("coduser");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cargo");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.CodCanton)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codCanton")
                    .IsFixedLength();

                entity.Property(e => e.CodCia)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("codCia");

                entity.Property(e => e.CodDepartamento)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codDepartamento")
                    .IsFixedLength();

                entity.Property(e => e.CodEstadoCivil)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codEstadoCivil")
                    .IsFixedLength();

                entity.Property(e => e.CodLicencia)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codLicencia")
                    .IsFixedLength();

                entity.Property(e => e.CodProvincia)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codProvincia")
                    .IsFixedLength();

                entity.Property(e => e.CodSexo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codSexo")
                    .IsFixedLength();

                entity.Property(e => e.Codcaracteristicas)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codcaracteristicas");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Movilidad)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movilidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telf)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("telf");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Valoracion).HasColumnName("valoracion");
            });

            modelBuilder.Entity<VersionCms>(entity =>
            {
                entity.HasKey(e => e.Version);

                entity.ToTable("versionCMS");

                entity.Property(e => e.Version)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("version")
                    .IsFixedLength();

                entity.Property(e => e.Fechafinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fechafinal");

                entity.Property(e => e.Fechainicial)
                    .HasColumnType("datetime")
                    .HasColumnName("fechainicial");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("observacion");
            });

            modelBuilder.Entity<Versionamiento>(entity =>
            {
                entity.ToTable("versionamiento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fechafinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fechafinal");

                entity.Property(e => e.Fechamodular)
                    .HasColumnType("datetime")
                    .HasColumnName("fechamodular");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Version)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("version")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}