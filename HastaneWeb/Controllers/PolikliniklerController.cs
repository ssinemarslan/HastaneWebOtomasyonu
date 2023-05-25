using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaneWeb.Models;

namespace HastaneWeb.Controllers
{
    public class PolikliniklerController : Controller
    {
        // GET: Poliklinikler
        HastaneWebEntities1 db = new HastaneWebEntities1();
        public ActionResult Index()
        {
            return View(db.PolikliniklerBilgis.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(PolikliniklerBilgi save)
        {
            try
            {
                using(HastaneWebEntities1 db=new HastaneWebEntities1())
                {
                    db.PolikliniklerBilgis.Add(save);
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
            using(HastaneWebEntities1 db=new HastaneWebEntities1())
            {
                return View(db.PolikliniklerBilgis.Where(x => x.PoliklinikNo == id).FirstOrDefault());
                
            }
        }
        [HttpPost]
        public ActionResult Edit(int id,PolikliniklerBilgi yenile)
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
                return View(db.PolikliniklerBilgis.Where(x => x.PoliklinikNo == id).FirstOrDefault());

            }
        }
        [HttpPost]
        public ActionResult Delete(int id,PolikliniklerBilgi sil)
        {
            using(HastaneWebEntities1 db=new HastaneWebEntities1())
            {
                sil = db.PolikliniklerBilgis.Where(x => x.PoliklinikNo == id).FirstOrDefault();
                db.PolikliniklerBilgis.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}