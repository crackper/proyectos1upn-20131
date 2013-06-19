using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;
using DBSystem.Repository;
using Microsoft.Practices.Unity;

namespace DBSystem.BusinessLogic
{
    public class ProductoBL:IProductoBL
    {
        [Dependency]
        public IProductoRepository ProductoRepository { get; set; }

        //IProductoRepository ProductoRepository;

        //public ProductoBL()
        //{
        //    ProductoRepository = new ProductoRepository();
        //}

        public List<Producto> GetFromProductoByCriterio(string criterio)
        {
            return ProductoRepository.GetFromProductoByCriterio(criterio);
        }

        public Producto GetFromProductoById(int id)
        {
            return ProductoRepository.GetFromProductoById(id);
        }

        public void AddProducto(Producto producto)
        {
            ProductoRepository.AddProducto(producto);
        }

        public void UpdateProducto(Producto producto)
        {
            ProductoRepository.UpdateProducto(producto);
        }

        public void RemoveProducto(int id)
        {
            ProductoRepository.RemoveProducto(id);
        }
    }
}
