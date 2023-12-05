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
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Categorias> categorias = db.Categorias.Include(d => d.Producto).ToList();
            return View(categorias);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(Categorias categoria)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
            }
            return Redirect("/Categorias/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Categorias ca = db.Categorias.Find(id);
            if (ca == null)
            {
                return HttpNotFound();
            }
            return View(ca);
        }

        [HttpPost]

        public ActionResult Modificar(Categorias categorias)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var ca = db.Categorias.Find(categorias.IdCategoria);

            if (TryUpdateModel(ca, "", new string[] { "idGarantia", "Nombre", "Descripcion" }))
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
            return Redirect("/Categorias/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var ca = db.Categorias.Find(id);
                db.Categorias.Remove(ca);
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
            Categorias ca = db.Categorias.Find(id);
            if (ca == null)
            {
                return HttpNotFound();
            }
            return View(ca);
        }

    }
}