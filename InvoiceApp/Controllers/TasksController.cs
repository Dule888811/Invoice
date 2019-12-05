using InvoiceApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.Models;

namespace InvoiceApp.Controllers
{
    public class TasksController : Controller
    {
      //  private Models.InvoiceApp db = new Models.InvoiceApp();
        private readonly ITasksRepository _tasksRepository;
    public TasksController(ITasksRepository TasksRepository)
    {
        this._tasksRepository = TasksRepository;
    }
    public ActionResult Index()
    {
        return View();
    }
    public ActionResult Create()
    {
        return View();
    }



    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Task Task = this._tasksRepository.GetById((int)id);

        if (Task == null)
        {
            return HttpNotFound();
        }
        return View(Task);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Task Task = this._tasksRepository.GetById((int)id);
        if (Task == null)
        {
            return HttpNotFound();
        }
            return View(Task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "id,Cena,Kolicina,Ukupno, RedniBroj, Document_id")] Task Task)

    {
      
        Task.Ukupno = Task.Cena * Task.Kolicina;
   
        if (ModelState.IsValid)
        {

                this._tasksRepository.EditTask(Task);
                return RedirectToAction("Index", "ComView", new { id = @Task.Document_id });
            }
            else
                return View(Task);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cena,Kolicina,Document_id,RedniBroj,Ukupno")] Task Task)
        {
            Task.Ukupno = Task.Kolicina * Task.Cena;
            Random randObj = new Random();
            var RedniBr = this._tasksRepository.Get().ToList();
            Task.RedniBroj = randObj.Next();
            if (ModelState.IsValid)
            {
                this._tasksRepository.AddTask(Task);

                return RedirectToAction("Index","ComView", new { id = @Task.Document_id });
            }else

            return View(Task);
        }

      

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteTasks(int id)
    {
        Task Task = this._tasksRepository.GetById((int)id);
        this._tasksRepository.DeleteTask(id);
        return RedirectToAction("Index", "ComView", new { id = @Task.Document_id });
        }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this._tasksRepository.Dispose();
        }
        base.Dispose(disposing);
    }
}
    
}