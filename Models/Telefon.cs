using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Telefon
    {
        internal List<CategorieTelefoane> CategorieTelefoane;
        public static IEnumerable<object> NumeCategorie { get; internal set; }
        public int ID { get; set; }
        [Display(Name = "Numele Telefonului")]
        public string Denumire { get; set; }
        [Display(Name = "Sistem de operare")]
        public string So { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLansarii { get; set; }
        public int IDProducator { get; set; }
        public Producator Producator { get; set; }

       
    }
}
