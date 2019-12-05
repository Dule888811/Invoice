using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceApp.Models
{
    public class InvoiceApp : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Task>()
                .HasRequired<Document>(s => s.Document)
                .WithMany(g => g.Tasks)
                .HasForeignKey<int>(s => s.Document_id);
        }

    }
}