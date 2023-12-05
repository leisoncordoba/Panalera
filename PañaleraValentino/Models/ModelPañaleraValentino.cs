namespace PañaleraValentino.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelPañaleraValentino : DbContext
    {
        public ModelPañaleraValentino()
            : base("name=ModelPañaleraValentino")
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Devoluciones> Devoluciones { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Garantia> Garantia { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductosXProveedores> ProductosXProveedores { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentaXVendedores> VentaXVendedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Categorias>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.RazonSocial)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nit)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Facturas)
                .WithRequired(e => e.Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Facturas>()
                .Property(e => e.IVA)
                .IsUnicode(false);

            modelBuilder.Entity<Facturas>()
                .Property(e => e.Total)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.UnidEmpaque)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CostoUnidad)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CantMinPedir)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CantMaxPedir)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PuntoPedido)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Facturas)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.ProductosXProveedores)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductosXProveedores>()
                .Property(e => e.Unidadespedidas)
                .IsUnicode(false);

            modelBuilder.Entity<ProductosXProveedores>()
                .Property(e => e.FechaEntrega)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.NombreCompañia)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.NombreContacto)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.ProductosXProveedores)
                .WithRequired(e => e.Proveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .HasMany(e => e.VentaXVendedores)
                .WithRequired(e => e.Vendedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ventas>()
                .Property(e => e.Precio)
                .IsUnicode(false);

            modelBuilder.Entity<Ventas>()
                .Property(e => e.IVA)
                .IsUnicode(false);

            modelBuilder.Entity<Ventas>()
                .Property(e => e.Total)
                .IsUnicode(false);

            modelBuilder.Entity<Ventas>()
                .HasMany(e => e.VentaXVendedores)
                .WithRequired(e => e.Ventas)
                .WillCascadeOnDelete(false);
        }
    }
}
