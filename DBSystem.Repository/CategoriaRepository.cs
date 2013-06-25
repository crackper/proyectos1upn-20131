using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;

namespace DBSystem.Repository
{
    public class CategoriaRepository:MasterRepository,ICategoriaRepository
    {
        public List<Categoria> GetAllFromCategoria()
        {
            return Context.Categorias.ToList();
        }
    }
}
