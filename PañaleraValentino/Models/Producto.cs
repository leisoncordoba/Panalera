namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Devoluciones = new HashSet<Devoluciones>();
            Facturas = new HashSet<Facturas>();
            Garantia = new HashSet<Garantia>();
            ProductosXProveedores = new HashSet<ProductosXProveedores>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }

        public int? IdCategoria { get; set; }

        public int? IdUbicacion { get; set; }

        [StringLength(25)]
        public string UnidEmpaque { get; set; }

        [Required]
        [StringLength(25)]
        public string CostoUnidad { get; set; }

        public int Stock_Final { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(25)]
        public string CantMinPedir { get; set; }

        [Required]
        [StringLength(25)]
        public string CantMaxPedir { get; set; }

        [Required]
        [StringLength(25)]
        public string PuntoPedido { get; set; }

        public virtual Categorias Categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Devoluciones> Devoluciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facturas> Facturas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Garantia> Garantia { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductosXProveedores> ProductosXProveedores { get; set; }
    }
}
