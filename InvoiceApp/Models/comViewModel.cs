using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Models
{
    public class comViewModel
    {
        public Document Document { get; set; }
        public Task Task { get; set; }
        public List<Document> Documents { get; set; }
        public List<Task> Tasks { get; set; }
    }
}