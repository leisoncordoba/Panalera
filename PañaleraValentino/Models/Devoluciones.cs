namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Devoluciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDevoluciones { get; set; }

        public int? idProducto { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
