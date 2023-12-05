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
    public class GarantiaController : Controller
    {
        // GET: Garantia
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Garantia> garantia = db.Garantia.Include(d => d.Producto).Include(a => a.Vendedores).ToList();
            //List<Garantia> garantia = db.Garantia.ToList();
            return View(garantia);
            //return View();

        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(Garantia garantia)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Garantia.Add(garantia);
                db.SaveChanges();
            }
            return Redirect("/Garantia/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Garantia ga = db.Garantia.Find(id);
            if (ga == null)
            {
                return HttpNotFound();
            }
            return View(ga);
        }

        [HttpPost]

        public ActionResult Modificar(Garantia garantia)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var ga = db.Garantia.Find(garantia.idGarantia);

            if (TryUpdateModel(ga, "", new string[] { "idGarantia", "idProducto", "IdVendedor" }))
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
            return Redirect("/Garantia/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var ga = db.Garantia.Find(id);
                db.Garantia.Remove(ga);
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
            Garantia ga = db.Garantia.Find(id);
            if (ga == null)
            {
                return HttpNotFound();
            }
            return View(ga);
        }
    }
}