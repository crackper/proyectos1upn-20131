﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;

namespace DBSystem.Repository
{
    public class ProductoRepository:
        MasterRepository,IProductoRepository
    {
        public List<Producto> GetFromProductoByCriterio(string criterio)
        {
            var query = from p in Context.Productoes.Include("Categoria")
                        select p;

            if (criterio !=null && criterio !="" && criterio != string.Empty)
            {
                query = from p in query
                        where p.Codigo.ToUpper().Contains(criterio.ToUpper()) ||
                              p.Descripcion.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }           

            return query.OrderBy(p=>p.Id).Take(10).Skip(0).ToList();
        }

        public Producto GetFromProductoById(int id)
        {
            return Context.Productoes.Find(id);
        }

        public void AddProducto(Producto producto)
        {
            Context.Productoes.Add(producto);
            Context.SaveChanges();
        }

        public void UpdateProducto(Producto producto)
        {
            Context.Entry(producto).State = System.Data.EntityState.Modified;
            Context.SaveChanges();
        }

        public void RemoveProducto(int id)
        {
            var producto = Context.Productoes.Find(id);

            if (producto != null)
            {
                Context.Productoes.Remove(producto);
                Context.SaveChanges();
            }
        }

        public Producto GetFromProductoByCodigo(string codigo)
        {
            var producto = Context.Productoes.Where(p => p.Codigo.Equals(codigo));
            return producto.SingleOrDefault();
        }
    }
}
