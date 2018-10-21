using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class CartsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Carts
        [Authorize]
        public ActionResult Index()
        {
            string un = User.Identity.GetUserName();
            var carts = db.Carts.Where(c => c.ApplicationUser.UserName==un );
            
            
            return View(carts.ToList());
        }

        // GET: Carts/Details/5
       
        [Authorize]
        [HttpPost]
        public ActionResult Add()
        {
            int foodid = Int32.Parse(Request.Form["fid"]);
            string un = User.Identity.GetUserName();
            Cart c1 = db.Carts.Where(ca => ca.fid == foodid && ca.UserName == un).FirstOrDefault();
            if (c1 == null)
            {
                Cart c = new Cart { UserName = User.Identity.GetUserName(), fid = foodid, qty = 1 };
                db.Carts.Add(c);
                db.SaveChanges();
            }
            else
            {
                c1.qty++;
                db.Entry(c1).State = EntityState.Modified;
                db.SaveChanges();
            }
            TempData["msg"] = "<script>alert('Added succesfully');</script>";
            return RedirectToAction("Index","");
        }

        [HttpPost]
        public ActionResult editqp()
        {
            int caid = Int32.Parse(Request.Form["cid"]);
            Cart c = db.Carts.Find(caid);
            if (c == null)
            {
                return HttpNotFound();
            }
            c.qty++;
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult editqm()
        {
            int caid = Int32.Parse(Request.Form["cid"]);
            Cart c = db.Carts.Find(caid);
            if (c == null)
            {
                return HttpNotFound();
            }
            c.qty--;
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove()
        {
            int caid = Int32.Parse(Request.Form["cid"]);
            Cart c = db.Carts.Find(caid);
            db.Carts.Remove(c);
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
