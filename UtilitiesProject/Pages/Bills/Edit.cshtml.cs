using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UtilitiesProject.Data;
using UtilitiesProject.Models;
using UtilitiesProject.Models.ViewModels;

namespace UtilitiesProject.Pages.Bills
{
    public class EditModel : PageModel
    {
        private readonly UtilityContext dbContext;
        protected string UtilityName = "None";
        private Bill bill;
        public List<SelectListItem> options { get; set; }

        public EditModel(UtilityContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [BindProperty]
        public EditUtilityViewModel AddUtilityRequest { get; set; }
        [BindProperty]
        public EditBillViewModel EditBillViewModel { get; set; }
        private Guid billId;
        public void OnGet(Guid id)
        {
            billId = id;
            Console.WriteLine(id);
            // Create ViewModel Bills
            bill = dbContext.findBillById(id);
            UtilityName = dbContext.findUtilityNameById(bill.UtilityID);
            Console.WriteLine(UtilityName + bill.Id + " " + bill.Amount + " " +bill.Paid);


            if (bill != null)
            {
                EditBillViewModel = new EditBillViewModel()
                {
                    Id = bill.Id,
                    Amount = bill.Amount,
                    Paid = bill.Paid
                };
                Console.WriteLine("Edit Bill View Model ID " + EditBillViewModel.Id);

            }

            else { Console.WriteLine("Bill was Null"); }
            Console.WriteLine("Edit Bill View Model ID " + EditBillViewModel.Id);

            // Generate Utility Names
            options = dbContext.Utilities.Select(a => new SelectListItem
            {
                Value = a.Name,
                Text = a.Name
            }).ToList();
        }
        public void OnPostUpdate()
        {

            if (bill != null)
            {
                EditBillViewModel = new EditBillViewModel()
                {
                    Id = bill.Id,
                    Amount = bill.Amount,
                    Paid = bill.Paid
                };
                Console.WriteLine("Edit Bill View Model ID " + EditBillViewModel.Id);

            }
            else { Console.WriteLine("Bill was null ID: " + billId); }
            Console.WriteLine("Edit Bill View Model ID " + EditBillViewModel.Id);
            if (EditBillViewModel != null)
            {
                var existingBill = dbContext.Bills.Find(EditBillViewModel.Id);
                if (existingBill != null)
                {
                    //Convert ViewModel to Domain Model
                    existingBill.Amount = EditBillViewModel.Amount;
                    existingBill.Paid = EditBillViewModel.Paid;

                    dbContext.SaveChanges();
                    ViewData["Message"] = "Bill Updated Successfuly";

                }
                else 
                { ViewData["Message"] = "Couldn't Update Bill1" + EditBillViewModel.Id; }
            }
            else
            { ViewData["Message"] = "Couldn't Update Bill - Null"; }
        }
        public IActionResult OnPostDelete()
        {
            var existingUtility = dbContext.Utilities.Find(EditBillViewModel.Id);

            if (existingUtility != null)
            {
                dbContext.Remove(existingUtility);
                dbContext.SaveChanges();
            }
            return RedirectToPage("/Utilities/List");

        }
    }
}
