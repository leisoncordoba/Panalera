namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VentaXVendedores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numventa { get; set; }

        public int IdVendedor { get; set; }

        public int IdVenta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeVenta { get; set; }

        public virtual Vendedores Vendedores { get; set; }

        public virtual Ventas Ventas { get; set; }
    }
}
