namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proveedor")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            ProductosXProveedores = new HashSet<ProductosXProveedores>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreCompañia { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreContacto { get; set; }

        [Required]
        [StringLength(25)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(25)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(25)]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Observaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductosXProveedores> ProductosXProveedores { get; set; }
    }
}
