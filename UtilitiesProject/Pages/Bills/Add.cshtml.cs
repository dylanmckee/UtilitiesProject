using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UtilitiesProject.Data;
using UtilitiesProject.Models;
using UtilitiesProject.Models.ViewModels;

namespace UtilitiesProject.Pages.Bills
{
    public class AddModel : PageModel
    {
        private readonly UtilityContext dbContext;

        public AddModel(UtilityContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public AddBillViewModel AddBillRequest { get; set; }
        [BindProperty]
        public AddUtilityViewModel AddUtilityRequest { get; set; }
        public Utility utility { get; set; }
        public List<Utility> utilities { get; set; }
        public List<string> utilNames { get; set; }
        public List<SelectListItem> options { get; set; }
        [BindProperty]
        public String selectedUtil { get; set; }
        public void OnGet()
        {
            utilities = dbContext.Utilities.ToList();
            //foreach(Utility utility in utilities) 
            //{ 
            //    utilNames.Add(utility.Name);
            //}
            options = dbContext.Utilities.Select(a => new SelectListItem { 
                Value=a.Name, Text = a.Name
                }).ToList();

        }
        public void OnPost() 
        {
            Console.WriteLine("Selected util: " + selectedUtil);
            // Convert ViewModel to DomainModel
            utility = dbContext.findByName(AddUtilityRequest.Name);

            if (utility != null)
            {
                var billDomainModel = new Bill
                {
                    UtilityID = utility.Id,
                    Amount = AddBillRequest.Amount,
                    Paid = AddBillRequest.Paid
                };
                dbContext.Bills.Add(billDomainModel);
                dbContext.SaveChanges();
                ViewData["Message"] = "Bill created successfully";
            }

            else {

                Console.WriteLine("Selected util was null" + "\n" + AddUtilityRequest.Name + "\n" 
                + utility.Id); }

        }
    }
}
