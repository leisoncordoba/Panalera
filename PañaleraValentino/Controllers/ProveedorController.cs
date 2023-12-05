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
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<Proveedor> proveedor = db.Proveedor.Include(d => d.ProductosXProveedores).ToList();
            return View(proveedor);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Guardar(Proveedor proveedor)
        {
            using (var da = new ModelPañaleraValentino())
            {
                da.Proveedor.Add(proveedor);
                da.SaveChanges();
            }
            return Redirect("/Proveedor/Index");
        }


        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Proveedor pr = db.Proveedor.Find(id);
            if (pr == null)
            {
                return HttpNotFound();
            }
            return View(pr);
        }

        [HttpPost]

        public ActionResult Modificar(Proveedor proveedor)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var pr = db.Proveedor.Find(proveedor.IdProveedor);

            if (TryUpdateModel(pr, "", new string[] {  "NombreCompañia", "NombreContacto", "Ciudad", "Direccion", "Telefono", "FechaRegistro", "Email", "Observaciones" }))
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
            return Redirect("/Proveedor/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var pr = db.Proveedor.Find(id);
                db.Proveedor.Remove(pr);
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
            Proveedor pr = db.Proveedor.Find(id);
            if (pr == null)
            {
                return HttpNotFound();
            }
            return View(pr);
        }

    }
}