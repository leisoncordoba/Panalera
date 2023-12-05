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
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Ventas> ventas = db.Ventas.Include(d => d.VentaXVendedores).ToList(); 
            return View(ventas);
        }


        public ActionResult Crear() {
            return View();
        }
        [HttpPost]

        public ActionResult Guardar(Ventas ventas) {
            using (var db = new ModelPañaleraValentino()) {
                db.Ventas.Add(ventas);
                db.SaveChanges();
            }
            return Redirect("/Ventas/Index");
        }
        [HttpGet]

        public ActionResult Editar(int? id) {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Ventas ven = db.Ventas.Find(id);
            if (ven==null)
            {
                return HttpNotFound();
            }
            return View(ven);
        }

        [HttpPost]

        public ActionResult Modificar(Ventas ventas) {
            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var ven = db.Ventas.Find(ventas.IdVenta);
            if (TryUpdateModel(ven,"",new string[] { "IdVenta", "Fecha", "Precio", "Descuento", "IVA", "Total" }))
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
            return Redirect("/Ventas/Index");
        }
        [HttpGet]

        public ActionResult Eliminar(int? id) {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var ven = db.Ventas.Find(id);
                db.Ventas.Remove(ven);
                db.SaveChanges();
            }
            catch (DataException e)
            {

                ModelState.AddModelError("", e);
            }
            return RedirectToAction("Index");

        }
        [HttpGet]

        public ActionResult Detalles(int? id) {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Ventas ven = db.Ventas.Find(id);
            if (ven==null)
            {
                return HttpNotFound();
            }
            return View(ven);
        }
    }
}