using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using intelex_interview.Models;

namespace intelex_interview.Controllers
{
    public class FoldersController : Controller
    {
        folders fobj = new folders();

        // GET: Folders
        public ActionResult Index()
        {
            var allfolders = fobj.getAllFolders();

            if (allfolders == null)
                ViewBag.count = 0;

            return View(allfolders);
        }

        // GET: Folders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Folders/Create
        public ActionResult Create()
        {
            var allfolders = fobj.getAllFolders();

            if (allfolders == null)
            {
                ViewBag.count = 0;
                return View();
            }
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var record in allfolders)
            {
                items.Add(new SelectListItem { Text = record.Name, Value = record.Id.ToString() });                
            }

            ViewBag.folders = items;

            return View();
        }

        // POST: Folders/Create
        [HttpPost]
        public ActionResult Create(structure newFolder, FormCollection collection)
        {
            newFolder.Parent_Id = Convert.ToInt32(collection["folders"]);

            if (ModelState.IsValid)
            {
                try
                {
                    // insert logic here

                    fobj.addfolder(newFolder);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        // GET: Folders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Folders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Folders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Folders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
