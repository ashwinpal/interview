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
            {
                ViewBag.count = 0;
                return View();
            }

            List<folderListModel> arrangedFolders = new List<folderListModel>();

            foreach( var record in allfolders)
            {
                folderListModel fl = new folderListModel();

                fl.Id = record.Id;
                fl.Name = record.Name;
                fl.Parent_Id = record.Parent_Id;
                
                arrangedFolders.Add(fl);
            }

            foreach (folderListModel fol in arrangedFolders)
            {
                fol.subfolders = new List<folderListModel>();

                foreach(folderListModel subfol in arrangedFolders)
                {
                    if (fol.Id == subfol.Parent_Id)
                        fol.subfolders.Add(subfol);
                }

            }

            arrangedFolders = arrangedFolders.OrderBy(x => x.Parent_Id).ToList();
           

            return View(arrangedFolders);
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
            

            if (ModelState.IsValid)
            {
                try
                {
                    // insert logic here
                    newFolder.Parent_Id = Convert.ToInt32(collection["folders"]);
                    fobj.addfolder(newFolder);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Create");
                }
            }

            return RedirectToAction("Create");
        }
    }
}
