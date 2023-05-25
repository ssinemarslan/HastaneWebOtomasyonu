using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaneWeb.Models;

namespace HastaneWeb.Controllers
{
    public class DoktorlarController : Controller
    {
        // GET: Doktorlar
        HastaneWebEntities1 db = new HastaneWebEntities1();
        public ActionResult Index()
        {
            return View(db.DoktorlarBilgis.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(DoktorlarBilgi save)
        {
            try
            {
                using (HastaneWebEntities1 db = new HastaneWebEntities1())
                {
                    db.DoktorlarBilgis.Add(save);
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
            using (HastaneWebEntities1 db=new HastaneWebEntities1())
            {
                return View(db.DoktorlarBilgis.Where(x => x.DoktorNo == id).FirstOrDefault());

            }
            
                
            
        }
        [HttpPost]
        public ActionResult Edit(int id,DoktorlarBilgi yenile)
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
                return View(db.DoktorlarBilgis.Where(x => x.DoktorNo == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(int id,DoktorlarBilgi sil)
        {
            using (HastaneWebEntities1 db = new HastaneWebEntities1())
            {
                sil=db.DoktorlarBilgis.Where(x=>x.DoktorNo==id).FirstOrDefault();
                db.DoktorlarBilgis.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}