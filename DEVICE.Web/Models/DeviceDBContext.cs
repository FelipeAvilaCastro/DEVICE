using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class DeviceDBContext : DbContext
    {
        public DeviceDBContext()
        {
        }

        public DeviceDBContext(DbContextOptions<DeviceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Correo> Correo { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<DocumentoDetalle> DocumentoDetalle { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fabricante> Fabricante { get; set; }
        public virtual DbSet<Licencia> Licencia { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Parte> Parte { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonaProducto> PersonaProducto { get; set; }
        public virtual DbSet<PersonaProductoEvidencia> PersonaProductoEvidencia { get; set; }
        public virtual DbSet<PersonaUbicacion> PersonaUbicacion { get; set; }
        public virtual DbSet<Procesador> Procesador { get; set; }
        public virtual DbSet<ProcesadorGeneracion> ProcesadorGeneracion { get; set; }
        public virtual DbSet<ProcesadorVelocidad> ProcesadorVelocidad { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoLicencia> ProductoLicencia { get; set; }
        public virtual DbSet<ProductoLicenciaEvidencia> ProductoLicenciaEvidencia { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<SistemaOperativo> SistemaOperativo { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<SoftwareModulo> SoftwareModulo { get; set; }
        public virtual DbSet<SoftwareVersion> SoftwareVersion{ get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<SucursalDepartamento> SucursalDepartamento { get; set; }
        public virtual DbSet<SucursalProducto> SucursalProducto { get; set; }
        public virtual DbSet<SucursalProductoEvidencia> SucursalProductoEvidencia { get; set; }
        public virtual DbSet<TipoDD> TipoDD { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Server=LAPTOP-SOPORTE\\SQLSERVER;Database=DeviceDB;Trusted_Connection=true;MultipleActiveResultSets=true;User=sa;Pwd=SQLServer");
                //optionsBuilder.UseSqlServer("Server=DBCRIOPUEBLA\\SQLEXPRESS;Database=DeviceDB;Trusted_Connection=true;MultipleActiveResultSets=true;User=sa;Pwd=SQLServer01");


                //optionsBuilder.UseSqlServer("Server=192.168.17.85;Database=DeviceDB;User=sa;Pwd=SQLServer");
                //optionsBuilder.UseSqlServer("Server=SERVER-SOPTEC\\SQLEXPRESS;Database=DeviceDB;User=sa;Pwd=SQLServer");


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

           
            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

            });



            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(150);

            });


            modelBuilder.Entity<Correo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(50);

                
            });


            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentoEncabezado).HasMaxLength(50);

                entity.Property(e => e.FechaDocumento).HasColumnType("date");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.Observaciones).HasMaxLength(2000);
                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK_Documento_Proveedor");
            });

            modelBuilder.Entity<DocumentoDetalle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentoId).HasColumnName("DocumentoID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.DocumentoDetalle)
                    .HasForeignKey(d => d.DocumentoId)
                    .HasConstraintName("FK_DocumentoDetalle_Documento");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DocumentoDetalle)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_DocumentoDetalle_Producto");
            });


            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(150);

            });


            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Licencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SoftwareId).HasColumnName("SoftwareID");

                entity.Property(e => e.SoftwareModuloId).HasColumnName("SoftwareModuloID");

                entity.Property(e => e.SoftwareVersionId).HasColumnName("SoftwareVersionID");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.NumeroLicenciaTarjeta).HasMaxLength(100);
                
                entity.Property(e => e.NumeroLicenciaWeb).HasMaxLength(100);

                entity.Property(e => e.CorreoId).HasColumnName("CorreoID");

                entity.Property(e => e.Comentario).HasMaxLength(1000);

                entity.HasOne(d => d.Software)
                    .WithMany(p => p.Licencia)
                    .HasForeignKey(d => d.SoftwareId)
                    .HasConstraintName("FK_Licencia_Software");
            });


            modelBuilder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(150);
            });


            modelBuilder.Entity<Parte>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NoParte).HasColumnName("NoParte");

                entity.Property(e => e.Descripcion).HasMaxLength(1000);

                entity.Property(e => e.Entradas).HasColumnName("Entradas");

                entity.Property(e => e.Salidas).HasColumnName("Salidas");

                entity.Property(e => e.Stock).HasColumnName("Stock");

            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.Puesto).HasMaxLength(200);

                entity.Property(e => e.Materno).HasMaxLength(100);

                entity.Property(e => e.Nombres).HasMaxLength(10);

                entity.Property(e => e.Clave).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.DepartamentoID).HasColumnName("DepartamentoID");
                entity.Property(e => e.SucursalID).HasColumnName("SucursalID");

                entity.Property(e => e.Paterno)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(200);

                entity.Property(e => e.Usuario).HasMaxLength(100);
            });

            modelBuilder.Entity<PersonaProducto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
                
                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaProximaCambio).HasColumnType("datetime");
                
                entity.Property(e => e.ClasificacionId).HasColumnName("ClasificacionID");

                entity.Property(e => e.Comentario).HasMaxLength(2000);

                entity.Property(e => e.FechaLiberacion).HasColumnType("datetime");



                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.PersonaProducto)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_PersonaProducto_Persona");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.PersonaProducto)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_PersonaProducto_Producto");
            });

            modelBuilder.Entity<PersonaProductoEvidencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.NombreArchivo).HasMaxLength(200);

                entity.Property(e => e.PersonaProductoId).HasColumnName("PersonaProductoID");

                entity.Property(e => e.Tipo).HasMaxLength(20);

                entity.HasOne(d => d.PersonaProducto)
                    .WithMany(p => p.PersonaProductoEvidencia)
                    .HasForeignKey(d => d.PersonaProductoId)
                    .HasConstraintName("FK_PersonaProductoEvidencia_PersonaProducto");
            });

            modelBuilder.Entity<PersonaUbicacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaUbicacion).HasColumnType("datetime");

                entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

                entity.Property(e => e.UbicacionId).HasColumnName("UbicacionID");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.PersonaUbicacion)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_PersonaUbicacion_Persona");

                entity.HasOne(d => d.Ubicacion)
                    .WithMany(p => p.PersonaUbicacion)
                    .HasForeignKey(d => d.UbicacionId)
                    .HasConstraintName("FK_PersonaUbicacion_Ubicacion");

            });

            modelBuilder.Entity<Procesador>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });



            modelBuilder.Entity<ProcesadorGeneracion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });


            modelBuilder.Entity<ProcesadorVelocidad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });


            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comentario).HasMaxLength(200);

                entity.Property(e => e.FabricanteId).HasColumnName("FabricanteID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(80)
                    .HasColumnName("IP");

                entity.Property(e => e.Modelo).HasMaxLength(100);

                entity.Property(e => e.NumeroProducto).HasMaxLength(200);

                entity.Property(e => e.NumeroSerie).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.ProcesadorId).HasColumnName("ProcesadorID");

                entity.Property(e => e.ProcesadorGeneracionId).HasColumnName("ProcesadorGeneracionID");

                entity.Property(e => e.ProcesadorVelocidadId).HasColumnName("ProcesadorVelocidadID");

                entity.Property(e => e.SistemaOperativoId).HasColumnName("SistemaOperativoID");

                entity.Property(e => e.Ssidnombre)
                    .HasMaxLength(100)
                    .HasColumnName("SSIDNombre");

                entity.Property(e => e.Ssidpassword)
                    .HasMaxLength(100)
                    .HasColumnName("SSIDPassword");

                entity.Property(e => e.TipoProductoId).HasColumnName("TipoProductoID");

                entity.Property(e => e.Usuario).HasMaxLength(50);

                entity.HasOne(d => d.Fabricante)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.FabricanteId)
                    .HasConstraintName("FK_Producto_Fabricante");

                entity.HasOne(d => d.Procesador)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.ProcesadorId)
                    .HasConstraintName("FK_Producto_Procesador");

                entity.HasOne(d => d.SistemaOperativo)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.SistemaOperativoId)
                    .HasConstraintName("FK_Producto_SistemaOperativo");

                entity.HasOne(d => d.TipoProducto)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.TipoProductoId)
                    .HasConstraintName("FK_Producto_TipoProducto");
            });

            modelBuilder.Entity<ProductoLicencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaConfiguracion).HasColumnType("datetime");

                entity.Property(e => e.FechaDesinstalacion).HasColumnType("datetime");

                entity.Property(e => e.LicenciaId).HasColumnName("LicenciaID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Licencia)
                    .WithMany(p => p.ProductoLicencia)
                    .HasForeignKey(d => d.LicenciaId)
                    .HasConstraintName("FK_ProductoLicencia_Licencia");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoLicencia)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_ProductoLicencia_Producto");
            });


            modelBuilder.Entity<ProductoLicenciaEvidencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.NombreArchivo).HasMaxLength(200);

                entity.Property(e => e.ProductoLicenciaId).HasColumnName("ProductoLicenciaID");

                entity.Property(e => e.Tipo).HasMaxLength(50);

    //            entity.HasOne(d => d.ProductoLicencia)
    //.WithMany(p => p.ProductoLicenciaEvidencia)
    //.HasForeignKey(d => d.ProductoLicenciaId)
    //.HasConstraintName("FK_ProductoLicenciaEvidencia_ProductoLicencia");

            });





            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(150);
                
                entity.Property(e => e.RFC).HasMaxLength(50);
               
                entity.Property(e => e.RazonSocial).HasMaxLength(100);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Colonia).HasMaxLength(100);

                
                entity.Property(e => e.PaisID).HasColumnName("PaisID");

                entity.Property(e => e.EstadoID).HasColumnName("EstadoID");

                entity.Property(e => e.CiudadID).HasColumnName("CiudadID");


                entity.Property(e => e.CodigoPostal).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.SitioWeb).HasMaxLength(100);

                entity.Property(e => e.Contacto).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(100);

                entity.Property(e => e.Observacion).HasMaxLength(100);

                entity.Property(e => e.UsuarioRegistro).HasMaxLength(150);
                
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<SistemaOperativo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ZonaId).HasColumnName("ZonaID");

                entity.HasOne(d => d.Zona)
                    .WithMany(p => p.Sucursal)
                    .HasForeignKey(d => d.ZonaId)
                    .HasConstraintName("FK_Sucursal_Zona");
            });

            modelBuilder.Entity<SucursalDepartamento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.SucursalDepartamento)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK_SucursalDepartamento_Departamento");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.SucursalDepartamento)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("FK_SucursalDepartamento_Sucursal");
            });

            modelBuilder.Entity<SucursalProducto>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Comentario).HasMaxLength(2000);

                entity.Property(e => e.Estado).HasMaxLength(100);

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.SucursalProducto)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_SucursalProducto_Producto");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.SucursalProducto)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("FK_SucursalProducto_Sucursal");
            });

            modelBuilder.Entity<SucursalProductoEvidencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.NombreArchivo).HasMaxLength(200);

                entity.Property(e => e.SucursalProductoId).HasColumnName("SucursalProductoID");

                entity.Property(e => e.Tipo).HasMaxLength(20);

                entity.HasOne(d => d.SucursalProducto)
                    .WithMany(p => p.SucursalProductoEvidencia)
                    .HasForeignKey(d => d.SucursalProductoId)
                    .HasConstraintName("FK_SucursalProductoEvidencia_SucursalProducto");
            });

            modelBuilder.Entity<TipoDD>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
                
                //entity.Property(e => e.Status).HasMaxLength(50);
            });


            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
