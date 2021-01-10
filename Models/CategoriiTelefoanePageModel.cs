using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;

namespace Proiect.Models
{
    public class CategoriiTelefoanePageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectContext context,
        Telefon telefon)
        {
            var allCategories = context.Categorie;
            var categorieTelefoane = new HashSet<int>(
            telefon.CategorieTelefoane.Select(c => c.ID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    IDCategorie = cat.ID,
                    NumeCategorie = cat.NumeCategorie,
                    Assigned = CategorieTelefoane.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiTelefoane(ProiectContext context,
        string[] selectedCategories, Telefon telefonToUpdate)
        {
            if (selectedCategories == null)
            {
                telefonToUpdate.CategorieTelefoane = new List<CategorieTelefoane>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var TelefonCategories = new HashSet<int>
            (telefonToUpdate.CategorieTelefoane.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!CategorieTelefoane.Contains(cat.ID))
                    {
                        telefonToUpdate.CategorieTelefoane.Add(
                        new CategorieTelefoane
                        {
                            ID = telefonToUpdate.ID,
                            IDCategorie = cat.ID
                        });
                    }
                }
                else
                {
                    if (CategorieTelefoane.Contains(cat.ID))
                    {
                        CategorieTelefoane courseToRemove
                        = telefonToUpdate
                        .CategorieTelefoane
                        .SingleOrDefault(i => i.IDCategorie == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
