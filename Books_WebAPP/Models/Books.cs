using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books_WebAPP.Models
{
    public class Books
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Titulo")]
        public string title { get; set; }

        [Display(Name = "Descripcion")]
        public string description { get; set; }

        [Display(Name = "Cantidad de paginas")]
        public int pageCount { get; set; }

        [Display(Name = "Resumen")]
        public string excerpt { get; set; }

        [Display(Name = "Fecha de publicacion")]
        public DateTime publishDate { get; set; }
    }
}

