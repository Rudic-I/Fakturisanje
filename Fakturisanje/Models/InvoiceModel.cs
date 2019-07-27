using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fakturisanje.Models
{
    public class InvoiceModel
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [MaxLength(10, ErrorMessage = "Maksimum je 10 karaktera")]
        public string DocumentId { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [MaxLength(10, ErrorMessage = "Maksimum je 10 karaktera")]
        public string InvoiceId { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public DateTime InvoiceDate { get; set; }

        public double? Total { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}