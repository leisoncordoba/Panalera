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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Clientes> clientes = db.Clientes.Include(d => d.Facturas).ToList();
            return View(clientes);

        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(Clientes clientes)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
            }
            return Redirect("/Clientes/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Clientes cl = db.Clientes.Find(id);
            if (cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);
        }

        [HttpPost]

        public ActionResult Modificar(Clientes clientes)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var cl = db.Clientes.Find(clientes.IdCliente);

            if (TryUpdateModel(cl, "", new string[] { "Nombre",  "RazonSocial", "Nit", "Ciudad",  "Direccion", "Telefono",    "EMail"  }))
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
            return Redirect("/Clientes/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var cl = db.Clientes.Find(id);
                db.Clientes.Remove(cl);
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
            Clientes cl = db.Clientes.Find(id);
            if (cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);
        }

    }
}