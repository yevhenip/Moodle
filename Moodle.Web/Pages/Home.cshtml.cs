using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Moodle.Web.Pages
{
    [Authorize]
    public class Home : PageModel
    {
        
    }
}