namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendedores()
        {
            Garantia = new HashSet<Garantia>();
            VentaXVendedores = new HashSet<VentaXVendedores>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVendedor { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeRegistro { get; set; }

        [Required]
        [StringLength(25)]
        public string Telefono { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Garantia> Garantia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaXVendedores> VentaXVendedores { get; set; }
    }
}
