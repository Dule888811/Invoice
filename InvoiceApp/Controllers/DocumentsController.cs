using InvoiceApp.Models;
using InvoiceApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InvoiceApp.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        private readonly IDocumentsRepository _documentsRepository;



        public DocumentsController(IDocumentsRepository documentsRepository)
        {
            this._documentsRepository = documentsRepository;

        }
        public ActionResult Index()
        {
            List<Document> documents = this._documentsRepository.Get().ToList();
            return View(documents);
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
            Document Document = this._documentsRepository.GetById((int)id);
            if (Document == null)
            {
                return HttpNotFound();
            }
            return View(Document);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document Document = this._documentsRepository.GetById((int)id);
            //     Document.Ukupno = Document.Tasks.ToList().Select(c => c.Ukupno).Sum();
            if (Document == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "comView", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BrojFakture,Date,BrojDokument,Ukupno")] Document Document)
        {
            //Document document = this._documentsRepository.GetById(Document.id);

            if (ModelState.IsValid)
            {
                this._documentsRepository.EditDocument(Document);
                return RedirectToAction("Index");
            }
            return View(Document);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrojFakture,Date,BrojDokument,Ukupno")] Document Document)
        {
            Document.Ukupno = Convert.ToDouble(0);
         //   Document.Tasks = new Collection<Task>();
            Document.Date = DateTime.Today;
            List<Document> documents = new List<Document>();
            if (this._documentsRepository.Get() != null)
            {
                 documents = this._documentsRepository.Get().ToList();
            }
           
           
            if (documents != null && documents.Count() > 0)
            {
                foreach (var BrojDokument in documents)
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    var stringChars = new char[9];
                    var random = new Random();
                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }
                    var finalString = new String(stringChars);
                    if (BrojDokument.BrojDokument == finalString)
                    {
                        continue;
                    }
                    Document.BrojDokument = finalString;
                }
            }else
            {
                Document.BrojDokument = "PrviDoke";
            }
        





            if (ModelState.IsValid)
            {
                this._documentsRepository.AddDocument(Document);

                return RedirectToAction("Index");
            }


            return View(Document);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document Document = this._documentsRepository.GetById((int)id);
            if (Document == null)
            {
                return HttpNotFound();
            }
            return View(Document);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document Document = this._documentsRepository.GetById((int)id);
            this._documentsRepository.DeleteDocument(id);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._documentsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}