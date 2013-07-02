using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;

namespace DBSystem.BusinessLogic
{
    public interface IProductoBL
    {
        List<Producto> GetFromProductoByCriterio(string criterio);
        Producto GetFromProductoById(Int32 id);
        Producto GetFromProductoByCodidgo(string codigo);
        void AddProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void RemoveProducto(Int32 id);
    }
}
