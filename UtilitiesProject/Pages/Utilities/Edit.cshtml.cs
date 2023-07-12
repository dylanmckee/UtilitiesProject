using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtilitiesProject.Data;
using UtilitiesProject.Models;
using UtilitiesProject.Models.ViewModels;

namespace UtilitiesProject.Pages.Utilities
{
    public class EditModel : PageModel
    {
        private readonly UtilityContext dbContext;

        public EditModel(UtilityContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public EditUtilityViewModel EditUtilityViewModel { get; set; }
        public void OnGet(Guid id)
        {
            var utility = dbContext.Utilities.Find(id);

            if (utility != null) 
            {
                EditUtilityViewModel = new EditUtilityViewModel()
                {
                    Id = utility.Id,
                    Name = utility.Name,
                    Period = utility.Period
                };
            }
        }
        public void OnPostUpdate() 
        {
            if (EditUtilityViewModel != null)
            { 
                var existingUtility = dbContext.Utilities.Find(EditUtilityViewModel.Id);
                if (existingUtility != null)
                {
                    //Convert ViewModel to Domain Model
                    existingUtility.Name = EditUtilityViewModel.Name;
                    existingUtility.Period = EditUtilityViewModel.Period;

                    dbContext.SaveChanges();
                    ViewData["Message"] = "Employee Updated Successfuly";

                }
            }
        }
        public IActionResult OnPostDelete()
        {
            var existingUtility = dbContext.Utilities.Find(EditUtilityViewModel.Id);

            if (existingUtility != null)
            {
                dbContext.Remove(existingUtility);
                dbContext.SaveChanges();
            }
            return RedirectToPage("/Utilities/List");

        }
    }
}
