using System;
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

        [Dependency]
        public ICategoriaBL CategoriaBL { get; set; }

        public ProductoController()
        {
            //using (IUnityContainer container = new UnityContainer())
            //{
            //    container.LoadConfiguration();
            //    container.BuildUp(this.GetType(), this);
            //}
        }

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            var productos = ProductoBL.GetFromProductoByCriterio("");
            
            return View(productos);
        }

        [HttpPost]
        public ActionResult Index( string criterio="")
        {
            var productos = ProductoBL.GetFromProductoByCriterio(criterio);

            return Request.IsAjaxRequest() ? 
                        (ActionResult)PartialView("_resultProductos",productos): 
                        View(productos);
        }

        public ActionResult Details(Int32 id)
        {
            var producto = ProductoBL.GetFromProductoById(id);

            return PartialView("_details", producto);
        }

        public ActionResult Add()
        {
            var categorias = CategoriaBL.GetAllFromCategoria();

            ViewData["CategoriaId"] = new SelectList(categorias, "id", "descripcion");

            return PartialView("_add");
        }

        [HttpPost]
        public ActionResult Add(Producto producto)
        {
            var ok = false;
            var msg = "ERROR";

            if (ModelState.IsValid)
            {
                try
                {
                    ProductoBL.AddProducto(producto);
                    ok = true;
                    msg = "Producto Guardado correctamente";
                }
                catch (Exception ex)
                {
                    ok = false;
                    msg = ex.Message;
                }                
            }

            var rpt = new 
            {
                ok = ok,
                msg = msg
            };

            return Json(rpt, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Int32 id)
        {
            ProductoBL.RemoveProducto(id);
            var productos = ProductoBL.GetFromProductoByCriterio("");
            return PartialView("_resultProductos", productos);
        }

        public ActionResult Edit(Int32 id)
        { 
            var producto = ProductoBL.GetFromProductoById(id);
            var categorias = CategoriaBL.GetAllFromCategoria();

            ViewData["CategoriaId"] = new SelectList(categorias, "id", "descripcion",producto.CategoriaId);

            return PartialView("_edit", producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            var ok = false;
            var msg = "ERROR";

            if (ModelState.IsValid)
            {
                ProductoBL.UpdateProducto(producto);
                ok = true;
                msg = "Producto Actualizado correctamente";
            }

            var rpt = new
            {
                ok = ok,
                msg = msg
            };

            return Json(rpt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult validarProductoAjax(string codigo)
        {
            var producto = ProductoBL.GetFromProductoByCodigo(codigo);
            var ok = false;
            var msg = "No Existe..!!!";

            if (producto !=null)
            {
               ok = true;
               msg = string.Format("Ya existe el producto: {0} - {1}",
                                producto.Codigo,
                                producto.Descripcion); 
            }

            var rpt = new
            {
                ok = ok,
                msg = msg
            };

            return Json(rpt, JsonRequestBehavior.AllowGet);
        }
            

    }
}
