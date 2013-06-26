using System;
using System.Collections.Generic;
//improtar
using System.ComponentModel.DataAnnotations;

namespace DBSystem.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            this.DetallePedidoes = new List<DetallePedido>();
        }

        public int Id { get; set; }
        public int CategoriaId { get; set; }

        [Required(ErrorMessage="El Código Es requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage="La Descripcion es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage="El Precio es Requerido")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage="El Stock es requerdio")]
        public decimal Stock { get; set; }
        public byte[] Foto { get; set; }
        public bool Descontinuado { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
    }
}
