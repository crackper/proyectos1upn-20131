using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;

namespace DBSystem.Repository
{
    public class CategoriaRepositoy:MasterRepository,ICategoriaRepositoy
    {
        public List<Categoria> GetAllFromCategoria()
        {
            return Context.Categorias.ToList();
        }
    }
}
