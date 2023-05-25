using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaneWeb.Models;

namespace HastaneWeb.Controllers
{
    public class HastalarController : Controller
    {
        // GET: Hastalar
        HastaneWebEntities1 db = new HastaneWebEntities1();
        public ActionResult Index()
        {
            return View(db.HastalarBilgis.ToList());
        }
        //[HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(HastalarBilgi save)
        {
            try
            {
                using (HastaneWebEntities1 db = new HastaneWebEntities1()) 
                {
                    db.HastalarBilgis.Add(save);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            using (HastaneWebEntities1 db = new HastaneWebEntities1()) ;
            {
                return View(db.HastalarBilgis.Where(x => x.HastaNo == id).FirstOrDefault());

            }
        }
        [HttpPost]
        public ActionResult Edit(int id, HastalarBilgi yenile)
        {
            using (HastaneWebEntities1 db = new HastaneWebEntities1())
            {
                db.Entry(yenile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            using (HastaneWebEntities1 db = new HastaneWebEntities1())
            {
                return View(db.HastalarBilgis.Where(x => x.HastaNo == id).FirstOrDefault());

            }
        }
        [HttpPost]
        public ActionResult Delete(int id, HastalarBilgi sil)
        {
            using (HastaneWebEntities1 db = new HastaneWebEntities1())
            {
                sil = db.HastalarBilgis.Where(x => x.HastaNo == id).FirstOrDefault();
                db.HastalarBilgis.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}