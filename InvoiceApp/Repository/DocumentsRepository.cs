using InvoiceApp.Models;
using InvoiceApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository
{
    public class DocumentsRepository : BaseRepository, IDocumentsRepository
    {
        public DocumentsRepository(Models.InvoiceApp  context) : base(context)
        {

        }
        public IQueryable<Document> Get()
        {
            var invoices = from m in context.Documents
                           select m;
            if (invoices.Count() == 0)
            {
                return null;
            }
            return invoices;
        }





        public void EditDocument(Document Document)
        {
            context.Entry(Document).State = EntityState.Modified;
            base.SaveChanges();
        }
        public void AddDocument(Document Document)
        {
            context.Documents.Add(Document);
            base.SaveChanges();
        }
        public Document GetById(int id)
        {
            return context.Documents.Find(id);
        }
        public void DeleteDocument(int id)
        {
            Document Document = this.GetById(id);
            context.Documents.Remove(Document);
            base.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
