using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceApp.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int RedniBroj { get; set; }
        [Range(1, double.PositiveInfinity)]
        public double Cena { get; set; }
        [Range(1, double.PositiveInfinity)]
        public double Kolicina { get; set; }
        public double Ukupno { get; set; }
        [Display(Name = "Document")]
        public int Document_id { get; set; }
        [ForeignKey("Document_id")]
        public virtual Document Document { get; set; }
    }
}