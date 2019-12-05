using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceApp.Models;

namespace InvoiceApp.Repository
{
    public class BaseRepository
    {
        protected readonly Models.InvoiceApp context;

        public BaseRepository(Models.InvoiceApp context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}