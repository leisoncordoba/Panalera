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
    public class ProductosXProveedoresController : Controller
    {
        // GET: ProductosXProveedores
        public ActionResult Index()
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            List<ProductosXProveedores> productosxproveedores = db.ProductosXProveedores.Include(d => d.Proveedor).ToList();
            return View(productosxproveedores);
            
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Guardar(ProductosXProveedores productosxproveedores)
        {
            using (var db = new ModelPañaleraValentino())
            {
                db.ProductosXProveedores.Add(productosxproveedores);
                db.SaveChanges();
            }
            return Redirect("/ProductosXProveedores/Index");
        }

        [HttpGet]

        public ActionResult Editar(int? id)
        {
            ModelPañaleraValentino db = new ModelPañaleraValentino();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            ProductosXProveedores px = db.ProductosXProveedores.Find(id);
            if (px == null)
            {
                return HttpNotFound();
            }
            return View(px);
        }

        [HttpPost]

        public ActionResult Modificar(ProductosXProveedores productosxproveedores)
        {

            ModelPañaleraValentino db = new ModelPañaleraValentino();

            var px = db.ProductosXProveedores.Find(productosxproveedores.NumPedido);

            if (TryUpdateModel(px, "", new string[] { "IdProveedor", "idProducto",  "Unidadespedidas", "FechaEntrega", }))
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
            return Redirect("/ProductosXProveedores/Index");
        }

        [HttpGet]

        public ActionResult Eliminar(int? id)
        {
            try
            {
                ModelPañaleraValentino db = new ModelPañaleraValentino();
                var px = db.ProductosXProveedores.Find(id);
                db.ProductosXProveedores.Remove(px);
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
            ProductosXProveedores px = db.ProductosXProveedores.Find(id);
            if (px == null)
            {
                return HttpNotFound();
            }
            return View(px);
        }
    }
}