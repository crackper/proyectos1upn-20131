using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;
using DBSystem.Repository;
using Microsoft.Practices.Unity;

namespace DBSystem.BusinessLogic
{
    public class CategoriaBL:ICategoriaBL
    {
        [Dependency]
        public ICategoriaRepositoy CategoriaRepositoy { get; set; }

        public List<Categoria> GetAllFromCategoria()
        {
            return CategoriaRepositoy.GetAllFromCategoria();
        }
    }
}
