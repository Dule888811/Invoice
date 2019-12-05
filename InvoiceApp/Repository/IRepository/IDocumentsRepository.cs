using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository.IRepository
{
    public interface IDocumentsRepository
    {
        IQueryable<Document>Get();
        void EditDocument(Document Document);
        void AddDocument(Document Document);
        void DeleteDocument(int id);
        Document GetById(int id);
        void Dispose();
    }
}