using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Volvo_Teste.Models;

namespace Volvo_Teste.Controllers
{
    public class CaminhaoController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Caminhao
        public ActionResult Index()
        {
            return View(db.TB_Caminhao.ToList());
        }

        // GET: Caminhao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Caminhao tB_Caminhao = db.TB_Caminhao.Find(id);
            if (tB_Caminhao == null)
            {
                return HttpNotFound();
            }
            return View(tB_Caminhao);
        }

        // GET: Caminhao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caminhao/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Modelo,AnoFabricacao,AnoModelo")] TB_Caminhao tB_Caminhao)
        {
            if (ModelState.IsValid)
            {
                if (tB_Caminhao.AnoModelo != DateTime.Now.Year && tB_Caminhao.AnoModelo != DateTime.Now.Year + 1)
                {
                    tB_Caminhao.AnoModelo = 0;
                    return View(tB_Caminhao);
                }
                if (tB_Caminhao.AnoFabricacao != DateTime.Now.Year)
                {
                    tB_Caminhao.AnoFabricacao = 0;
                    return View(tB_Caminhao);
                }
                if (tB_Caminhao.Modelo != "FH" && tB_Caminhao.Modelo != "FM")
                {
                    tB_Caminhao.Modelo = "";
                    return View(tB_Caminhao);
                }
                db.TB_Caminhao.Add(tB_Caminhao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Caminhao);
        }

        // GET: Caminhao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Caminhao tB_Caminhao = db.TB_Caminhao.Find(id);
            if (tB_Caminhao == null)
            {
                return HttpNotFound();
            }
            return View(tB_Caminhao);
        }

        // POST: Caminhao/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Modelo,AnoFabricacao,AnoModelo")] TB_Caminhao tB_Caminhao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Caminhao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Caminhao);
        }

        // GET: Caminhao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Caminhao tB_Caminhao = db.TB_Caminhao.Find(id);
            if (tB_Caminhao == null)
            {
                return HttpNotFound();
            }
            return View(tB_Caminhao);
        }

        // POST: Caminhao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Caminhao tB_Caminhao = db.TB_Caminhao.Find(id);
            db.TB_Caminhao.Remove(tB_Caminhao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
