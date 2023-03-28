using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;

namespace DevelopersNet.vCard.Web.Pages
{
    public class ProfileModel : PageModel
    {
        public ProfileOptions? Profile { get; set; }

        public void OnGet([FromRoute]string employee)
        {
            ViewData["employee"] = employee;
            
            string filename = @$"Profiles\{employee.ToLower()}.json";
            if (!System.IO.File.Exists(filename))
            {
                Profile = null;
            }
            else
            {
                var text = System.IO.File.ReadAllText(filename);
                Profile = JsonSerializer.Deserialize<ProfileOptions>(text);
            }

        }
    }

    public class ProfileOptions
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }
        public string[] PublicProfilesUrl { get; set; }
    }
}
