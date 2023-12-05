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
    public class DevolucionesController : Controller
    {
        // GET: Devoluciones
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Devoluciones> devoluciones = db.Devoluciones.Include(d => d.Producto).ToList();
            return View(devoluciones);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(Devoluciones devoluciones)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Devoluciones.Add(devoluciones);
                db.SaveChanges();
            }
            return Redirect("/Devoluciones/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Devoluciones de = db.Devoluciones.Find(id);
            if (de == null)
            {
                return HttpNotFound();
            }
            return View(de);
        }

        [HttpPost]

        public ActionResult Modificar(Devoluciones devoluciones)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var de = db.Devoluciones.Find(devoluciones.idDevoluciones);

            if (TryUpdateModel(de, "", new string[] {  "idProducto" }))
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
            return Redirect("/Devoluciones/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var de = db.Devoluciones.Find(id);
                db.Devoluciones.Remove(de);
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
            Devoluciones de = db.Devoluciones.Find(id);
            if (de == null)
            {
                return HttpNotFound();
            }
            return View(de);
        }
    }
}