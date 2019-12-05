using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceApp.Models
{
    public class Document
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
       // [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string BrojDokument { get; set; }
        public int BrojFakture { get; set; }
        public double Ukupno { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}