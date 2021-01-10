using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Data;
using Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Telefon> Telefons { get; set; }
        public TelefonData TelefonD { get; set; }
        public int TelefonID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            TelefonD = new TelefonData();

            TelefonD.Telefoane = await _context.Telefon
            .Include(b => b.Producator)
            .Include(b => b.CategorieTelefoane)
            
            .AsNoTracking()
           
            .ToListAsync();
            if (id != null)
            {
                TelefonID = id.Value;
                Telefon film = TelefonD.Telefoane
                .Where(i => i.ID == id.Value).Single();
                TelefonD.Categories = film.CategorieTelefoane.Select(s => s.Categorie);
            }
        }
    }
}
