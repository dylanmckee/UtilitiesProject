using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtilitiesProject.Data;
using UtilitiesProject.Models;

namespace UtilitiesProject.Pages.Utilities
{
    public class ListModel : PageModel
    {
        private readonly UtilityContext dbContext;

        public List<Utility> Utilities { get; set; }
        public ListModel(UtilityContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Utilities = dbContext.Utilities.ToList();
        }
    }
}
