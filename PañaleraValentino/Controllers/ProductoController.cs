using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PañaleraValentino.Models;
using System.Data.Entity;
using System.Data;

namespace PañaleraValentino.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Producto> producto = db.Producto.Include(d => d.Garantia).ToList();
            return View(producto);
        }

        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]


        public ActionResult Guardar(Producto producto)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Producto.Add(producto);
                db.SaveChanges();
            }
            return Redirect("/Producto/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Producto pr = db.Producto.Find(id);
            if (pr == null)
            {
                return HttpNotFound();
            }
            return View(pr);
        }
        [HttpPost]

        public ActionResult Modificar(Producto producto)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var pr = db.Producto.Find(producto.IdProducto);

            if (TryUpdateModel(pr, "", new string[] { "IdProducto", "IdCategoria", "IdUbicacion", "UnidEmpaque", "CostoUnidad", "Stock_Final", "Descripcion", "CantMinPedir", "CantMaxPedir", "PuntoPedido" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException e)
                {

                    ModelState.AddModelError("", e);
                }

            }
            return Redirect("/Producto/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var pr = db.Producto.Find(id);
                db.Producto.Remove(pr);
                db.SaveChanges();
            }
            catch (DataException e)
            {

                ModelState.AddModelError("", e);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Detalles(int? id)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Producto pr = db.Producto.Find(id);
            if (pr == null)
            {
                return HttpNotFound();
            }
            return View(pr);
        }
    }
}