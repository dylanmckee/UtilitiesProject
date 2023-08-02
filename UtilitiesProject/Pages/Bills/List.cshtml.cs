using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtilitiesProject.Data;
using UtilitiesProject.Models;

namespace UtilitiesProject.Pages.Bills
{
    public class ListModel : PageModel
    {
        private readonly UtilityContext dbContext;
        public List<string> utilityNames;
        public List<Bill> Bills { get; set; }
        public ListModel(UtilityContext dbContext)
        {
            this.dbContext = dbContext;
            utilityNames = new List<string>();
        }
        public void OnGet()
        {
            Bills = dbContext.Bills.ToList();
            foreach(var bill in Bills) 
            {
                string name;
                name = dbContext.findUtilityNameById(bill.UtilityID);
                Console.WriteLine(name);

                utilityNames.Add(name);

            }
        }
    }
}
