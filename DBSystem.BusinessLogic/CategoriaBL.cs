using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using DBSystem.Entities;
using DBSystem.Repository;

namespace DBSystem.BusinessLogic
{
    public class CategoriaBL:ICategoriaBL
    {
        [Dependency]
        public ICategoriaRepository CategoriaRepository { get; set; }

        public List<Categoria> GetAllFromCategoria()
        {
            return CategoriaRepository.GetAllFromCategoria();
        }
    }
}
