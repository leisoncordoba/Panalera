namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facturas
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFacturas { get; set; }

        public int IdCliente { get; set; }

        public int IdProducto { get; set; }

        [Required]
        [StringLength(25)]
        public string IVA { get; set; }

        public int? detalle { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public int? descuento { get; set; }

        public int? subtotal { get; set; }

        [Required]
        [StringLength(25)]
        public string Total { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Producto Producto { get; set; }

    
    }
}
