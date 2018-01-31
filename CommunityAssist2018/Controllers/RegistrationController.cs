using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018.Models;

namespace CommunityAssist2018.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "NewPersonLastName,NewPersonFirstName,NewPersonEmail,NewPersonPhone,NewPersonPlainPassword,NewPersonApartment,NewPersonStreet,NewPersonCity,NewPersonState,NewPersonZipcode")]NewPerson r)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities(); 

            int result = db.usp_Register(r.NewPersonLastName, r.NewPersonFirstName, r.NewPersonEmail, r.NewPersonPhone, r.NewPersonPlainPassword, r.NewPersonApartment, r.NewPersonStreet, r.NewPersonCity, r.NewPersonState, r.NewPersonZipcode);

            if (result != -1)
            {
                return RedirectToAction("Result");
            }

            return View("Index");
        }
    }
}

