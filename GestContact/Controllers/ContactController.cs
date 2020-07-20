using GestContact.Models;
using GestContact.Tools;
using ModelLocal.Models;
using ModelLocal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestContact.Controllers
{
    
    public class ContactController : Controller
    {
        private ContactService _service;

        public ContactController()
        {
            _service = new ContactService();
        }

        // GET: Contact
        public ActionResult Index()
        {
            
            return View(_service.GetAll());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id));
        }

        // GET: Contact/Create
        [AuthRequired]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactForm c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Save(c.ToModel());

                    return RedirectToAction("Index");
                }

                else return View(c);
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        [AuthRequired]
        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactForm c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Update(c.ToModel());

                    return RedirectToAction("Index");
                }

                else return View(c);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        [AuthRequired]
        public ActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(Contact c)
        {
            try
            {
                _service.Delete(c.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FindForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Find(FindFormModel f)
        {
            try
            {
                return View(_service.FindByName(f.AChercher));
            }
            catch
            {
                return RedirectToAction("FindForm");
            }
        }
    }
}
