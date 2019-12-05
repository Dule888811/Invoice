using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceApp.Controllers
{
    public class comViewController : Controller
    {

        private comViewModel vm = new comViewModel();
        private Models.InvoiceApp db = new Models.InvoiceApp();
        // GET: comView
        public ActionResult Index(int? id)
        {
            //  List<Task> Tasks = new List<Task>();
            if (id == null)
            {
                vm.Document = null;
                vm.Tasks = null;
                return View(vm);
            }
            else
            {
                Document document = db.Documents.Find(id);
                if (document == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    vm.Document = document;
                    var Tasks = document.Tasks;
                    if (Tasks != null)
                    {
                        vm.Tasks = Tasks.ToList();
                    }
                    else
                    {
                        vm.Tasks = null;
                    }
                    return View(vm);
                }
            }
        }
    }
}