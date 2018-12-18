using Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ClientesController : Controller
    {

        private Context db = new Context();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Cadastros.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Nome,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Temperatura")] Cadastro cadastro)
        //{
        public ActionResult Create(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Cadastros.Add(cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }



        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastros.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastro);
        }

        public class Retorno
        {
            public bool sucess { get; set; }
            public int id { get; set; }
        }
        public JsonResult Delete(int? id)
        {
            Retorno ret = new Retorno();
            ret.id = id.Value;
            ret.sucess = false;
            if (id == null)
            {
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
            Cadastro cadastro = db.Cadastros.Find(id);
            if (cadastro == null)
            {
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
            db.Cadastros.Remove(cadastro);
            db.SaveChanges();
            ret.sucess = true;
            return Json(ret, JsonRequestBehavior.AllowGet);

        }


    }
}