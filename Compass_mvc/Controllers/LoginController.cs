using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compass_mvc.Models;

namespace Compass_mvc.Controllers
{
    public class LoginController : Controller
    {
        private Compass_MVCEntities db = new Compass_MVCEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //POST : Login
        [HttpPost]
        public ActionResult Login(Credentials data)
        {
            foreach (Credentials item in db.Credentials )
            {
                if( data.Email == item.Email && data.Password == item.Password)
                {
                    return View("Welcome");
                }
            }

            return View("Error");
        }

        //GET : Register
        [HttpGet]
         public ActionResult Register()
         {
            return View();
         }
           
        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create( Credentials credentials)
        {
            bool exist = false; 

            foreach (Credentials item in db.Credentials)
            {
                if(credentials.Email == item.Email)
                {
                    exist = true; 

                }
            }

            if( exist == true)
            {
                return RedirectToAction("Error");
            }

            db.Credentials.Add(credentials);
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
