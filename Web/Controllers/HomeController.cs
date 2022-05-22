using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Connectiondata;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            aadiEntities obj = new aadiEntities();
            var res = obj.radikas.ToList();

            return View(res);
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(Classdata obj1)
        {
            aadiEntities obj = new aadiEntities();
            radika obj2 = new radika();
            obj2.id = obj1.id;
            obj2.name = obj1.name;
            obj2.age = obj1.age;
            obj2.salary = obj1.salary;
            obj2.city = obj1.city;

            if (obj1.id == 0)
            {
                obj.radikas.Add(obj2);
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                obj.Entry(obj2).State = System.Data.EntityState.Modified;
                obj.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Delete(int Id)
        {
            aadiEntities obj = new aadiEntities();

            var del = obj.radikas.Where(m => m.id == Id).FirstOrDefault();

            obj.radikas.Remove(del);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult edit(int id)
        {
            aadiEntities obj = new aadiEntities();

            radika obj2 = new radika();
            var edit = obj.radikas.Where(m => m.id == id).First();
            obj2.id = edit.id;
            obj2.name = edit.name;
            obj2.age = edit.age;
            obj2.city = edit.city;
            obj2.salary = edit.salary;

         
            return View("Form", obj2);








        }
    }
}
