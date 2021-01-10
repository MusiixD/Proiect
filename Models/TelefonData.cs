using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class TelefonData
    {
        public IEnumerable<Telefon> Telefoane { get; set; }
        public IEnumerable<Categorie> Categories { get; set; }
        public IEnumerable<CategorieTelefoane> CategoriiTelefoane { get; set; }
    }
}
