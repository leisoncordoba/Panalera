namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Garantia")]
    public partial class Garantia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idGarantia { get; set; }

        public int? idProducto { get; set; }

        public int? idVendedor { get; set; }

        public virtual Vendedores Vendedores { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
