using crud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        joinsEntities db=new joinsEntities();
        public ActionResult Index()
        {

            return View(db.students.ToList());
        }
        public ActionResult Create()
        {

            return View();
        }   

        [HttpPost]
        public ActionResult Create(student std)
        {
            db.students.Add(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           var data= db.students.Find(id);
            db.students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        public ActionResult Edit(int id)
        {
        
            return View(db.students.Find(id));
        }
        [HttpPost]
		public ActionResult Edit(int id , student std)
		{
            var data=db.students.Find(id);
            db.students.AddOrUpdate(std,data);
            db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}