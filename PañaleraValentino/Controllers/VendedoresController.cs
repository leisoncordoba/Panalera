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
    public class VendedoresController : Controller
    {
        // GET: Vendedores
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Vendedores> vendedores = db.Vendedores.Include(d => d.VentaXVendedores).ToList();
            return View(vendedores);
        }

        public ActionResult Crear() {
            return View();
        }
        [HttpPost]


        public ActionResult Guardar(Vendedores vendedores) {
            using (var db = new ModelPañaleraValentino()) {
                db.Vendedores.Add(vendedores);
                db.SaveChanges();
            }
            return Redirect("/Vendedores/Index");
        }
        [HttpGet]

        public ActionResult Editar(int? id) {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id== null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Vendedores vend = db.Vendedores.Find(id);
            if (vend == null)
            {
                return HttpNotFound();
            }
            return View(vend);
        }
        [HttpPost]

        public ActionResult Modificar(Vendedores vendedores) {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var vend = db.Vendedores.Find(vendedores.IdVendedor);

            if (TryUpdateModel(vend, "", new string[] { "IdVendedor", "Nombre", "FechaDeRegistro", "Telefono", "Email" }))
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
            return Redirect("/Vendedores/Index");
        }
        [HttpGet]

        public ActionResult Eliminar(int? id) {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var vend = db.Vendedores.Find(id);
                db.Vendedores.Remove(vend);
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
            if (id== null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Vendedores vend = db.Vendedores.Find(id);
            if (vend == null)
            {
                return HttpNotFound();
            }
            return View(vend);
        }
    }
}