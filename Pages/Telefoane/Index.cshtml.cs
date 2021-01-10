using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Telefoane
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Telefon> Telefon { get;set; }
        public TelefonData TelefonD { get; set; }
        public int TelefonID { get; set; }
        public int IDCategorie { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            TelefonData telefonData = new TelefonData();
            TelefonD = telefonData;

            TelefonD.Telefoane = await _context.Telefon
            .Include(b => b.Producator)
            .Include(b => b.CategorieTelefoane)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                id = id.Value;
                Telefon book = TelefonD.Telefoane
                .Where(i => i.ID == id.Value).Single();
                TelefonD.Categories = book.CategorieTelefoane.Select(s => s.Categorie);
            }
        }

        public async Task OnGetAsync()
        {
            Telefon = await _context.Telefon
                .Include(b => b.Producator)
                .ToListAsync();
        }
    }
}
