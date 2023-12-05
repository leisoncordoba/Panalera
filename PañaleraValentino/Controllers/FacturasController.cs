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
    public class FacturasController : Controller
    {
        // GET: Facturas
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Facturas> facturas = db.Facturas.Include(d => d.Producto).ToList();
            return View(facturas);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(Facturas facturas)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Facturas.Add(facturas);
                db.SaveChanges();
            }
            return Redirect("/Facturas/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Facturas fa = db.Facturas.Find(id);
            if (fa == null)
            {
                return HttpNotFound();
            }
            return View(fa);
        }

        [HttpPost]

        public ActionResult Modificar(Facturas facturas)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var fa = db.Facturas.Find(facturas.IdFacturas);

            if (TryUpdateModel(fa, "", new string[] { "IdFacturas", "IdCliente", "IdProducto", "IVA", "detalle", "Fecha", "descuento", "subtotal", "Total" }))
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
            return Redirect("/Facturas/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var fa = db.Facturas.Find(id);
                db.Facturas.Remove(fa);
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
            Facturas fa = db.Facturas.Find(id);
            if (fa == null)
            {
                return HttpNotFound();
            }
            return View(fa);
        }
    }
}