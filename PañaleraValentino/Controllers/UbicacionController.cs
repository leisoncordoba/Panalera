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
    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Ubicacion> ubicacion = db.Ubicacion.Include(d => d.Producto).ToList();
            return View(ubicacion);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(Ubicacion ubicacion)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Ubicacion.Add(ubicacion);
                db.SaveChanges();
            }
            return Redirect("/Ubicacion/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Ubicacion ub = db.Ubicacion.Find(id);
            if (ub == null)
            {
                return HttpNotFound();
            }
            return View(ub);
        }

        [HttpPost]

        public ActionResult Modificar(Ubicacion ubicacion)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var ub = db.Ubicacion.Find(ubicacion.IdUbicacion);

            if (TryUpdateModel(ub, "", new string[] { "Nombre", "Area" }))
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
            return Redirect("/Ubicacion/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var ub = db.Ubicacion.Find(id);
                db.Ubicacion.Remove(ub);
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
            Ubicacion ub = db.Ubicacion.Find(id);
            if (ub == null)
            {
                return HttpNotFound();
            }
            return View(ub);
        }
    }
}