using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class CategorieTelefoane
    {
        public int ID { get; set; }
        public int IDTelefon { get; set; }
        public Telefon Telefon { get; set; }
        public int IDCategorie { get; set; }
        public Categorie Categorie { get; set; }

        internal static bool Contains(int iD)
        {
            throw new NotImplementedException();
        }
    }
}