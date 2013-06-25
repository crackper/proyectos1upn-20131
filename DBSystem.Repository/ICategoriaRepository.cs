﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSystem.Entities;

namespace DBSystem.Repository
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAllFromCategoria();
    }
}
