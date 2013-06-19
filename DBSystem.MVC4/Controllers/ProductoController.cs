﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBSystem.Entities;
using DBSystem.BusinessLogic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DBSystem.MVC4.Controllers
{
    public class ProductoController : Controller
    {
        [Dependency]
        public IProductoBL ProductoBL { get; set; }

        public ProductoController()
        {
            using (IUnityContainer container = new UnityContainer())
            {
                container.LoadConfiguration();
                container.BuildUp(this.GetType(), this);
            }
        }

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            var productos = ProductoBL.GetFromProductoByCriterio("");
            
            return View(productos);
        }

    }
}
