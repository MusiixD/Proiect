using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Telefoane
{
    public class EditModel : CategoriiTelefoanePageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Telefon Telefon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Telefon = await _context.Telefon
 .Include(b => b.Producator)
 .Include(b => b.CategorieTelefoane).ThenInclude(b => b.Categorie)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Telefon == null)
            {
                PopulateAssignedCategoryData(_context, Telefon);
                ViewData["IDProducator"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var telefonToUpdate = await _context.Telefon
            .Include(i => i.Producator)
            .Include(i => i.CategorieTelefoane)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (telefonToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Telefon>(
            telefonToUpdate,
            "Telefon",
            i => i.Denumire, i => i.So,
            i => i.Pret, i => i.DataLansarii, i => i.Producator))
            {
                UpdateCategoriiTelefoane(_context, selectedCategories, telefonToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCategoriiTelefoane(_context, selectedCategories, telefonToUpdate);
            PopulateAssignedCategoryData(_context, telefonToUpdate);
            return Page();
        }
    }
}
