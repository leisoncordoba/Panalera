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
    public class VentaXVendedoresController : Controller
    {
        // GET: VentaXVendedores
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<VentaXVendedores> ventaxvendedores = db.VentaXVendedores.Include(d => d.Ventas).ToList();
            return View(ventaxvendedores);
        }

        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]


        public ActionResult Guardar(VentaXVendedores ventaxvendedores)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.VentaXVendedores.Add(ventaxvendedores);
                db.SaveChanges();
            }
            return Redirect("/VentaXVendedores/Index");
        }
        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            VentaXVendedores vex = db.VentaXVendedores.Find(id);
            if (vex == null)
            {
                return HttpNotFound();
            }
            return View(vex);
        }

        [HttpPost]

        public ActionResult Modificar(VentaXVendedores ventaxvendedores)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var vex = db.VentaXVendedores.Find(ventaxvendedores.numventa);

            if (TryUpdateModel(vex, "", new string[] { "numventa",   "IdVendedor",  "IdVenta", "FechaDeVenta" }))
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
            return Redirect("/VentaXVendedores/Index");
        }
        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var vex = db.VentaXVendedores.Find(id);
                db.VentaXVendedores.Remove(vex);
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
            VentaXVendedores vex = db.VentaXVendedores.Find(id);
            if (vex == null)
            {
                return HttpNotFound();
            }
            return View(vex);
        }
    }

}