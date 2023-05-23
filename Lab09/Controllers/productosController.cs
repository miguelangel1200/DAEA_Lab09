using Lab09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab09.Controllers
{
    public class productosController : Controller
    {

        private NeptunoEntities db = new NeptunoEntities();

        // GET: productos
        public ActionResult Index()
        {
            return View(db.productos.ToList());
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] productos productos)
        {
            if (ModelState.IsValid)
            {
                int maxId = db.productos.Max(x => x.idproducto); 
                productos.idproducto = maxId + 1; 

                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }
    }
}