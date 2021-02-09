namespace Moodle.Web.Models
{
    public record LoginModel(string UserName, string Password, bool RememberMe)
    {
    }
}