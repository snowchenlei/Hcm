using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Snow.Hcm.Web.Pages.Employees.EmergencyContacts
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var partialView = new PartialViewResult();
            partialView.ViewName = "/Pages/Employees/EmergencyContacts/Index";
            return partialView;
        }
    }
}
