namespace PañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductosXProveedores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumPedido { get; set; }

        public int IdProveedor { get; set; }

        public int idProducto { get; set; }

        [Required]
        [StringLength(25)]
        public string Unidadespedidas { get; set; }

        [StringLength(25)]
        public string FechaEntrega { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
