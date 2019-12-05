using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository.IRepository
{
    public interface ITasksRepository
    {
        IQueryable<Task> Get();
        void EditTask(Task Task);
        void AddTask(Task Task);
        Task GetById(int id);
        void DeleteTask(int id);
        void Dispose();
    }
}