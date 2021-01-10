using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Telefoane
{
    public class CreateModel : CategoriiTelefoanePageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IDProducator"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");

            Telefon telefon1 = new Telefon();
            var telefon = telefon1;
            telefon.CategorieTelefoane = new List<CategorieTelefoane>();
            PopulateAssignedCategorieTelefoane(_context, telefon);

            return Page();
        }

        private void PopulateAssignedCategorieTelefoane(ProiectContext context, Telefon telefon)
        {
            throw new NotImplementedException();
        }

        [BindProperty]
        public Telefon Telefon { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newTelefon = new Telefon();
            if (selectedCategories != null)
            {
                newTelefon.CategorieTelefoane = new List<CategorieTelefoane>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieTelefoane
                    {
                        IDCategorie = int.Parse(cat)
                    };
                    newTelefon.CategorieTelefoane.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Telefon>(
            newTelefon,
            "Telefon",
            i => i.Denumire, i => i.Producator,
            i => i.Pret, i => i.DataLansarii, i => i.IDProducator))
            {
                _context.Telefon.Add(newTelefon);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newTelefon);
            return Page();
        }
    }
  
}
