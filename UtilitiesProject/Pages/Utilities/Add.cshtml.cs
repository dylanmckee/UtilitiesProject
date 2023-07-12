using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtilitiesProject.Data;
using UtilitiesProject.Models;
using UtilitiesProject.Models.ViewModels;

namespace UtilitiesProject.Pages.Utilities
{
    public class AddModel : PageModel
    {
        private readonly UtilityContext dbContext;

        public void OnGet()
        {
        }
        public AddModel(UtilityContext utilityContext)
        {
            this.dbContext = utilityContext;
        }
        [BindProperty]
        public AddUtilityViewModel AddUtilityRequest { get; set; }

        public void OnPost() 
        {
            // convert ViewModel to DomainModel

            var utilityDomainModel = new Utility
            {
                Name = AddUtilityRequest.Name,
                Period = AddUtilityRequest.Period
            };
            dbContext.Utilities.Add(utilityDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Utility created successfully";

        }
    }
}
