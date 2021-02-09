using System;

namespace Moodle.Web.Models
{
    public record CreateUserModel(string FullName, string UserName, string Email, string Phone, DateTime BirthDate,
        string Password, string PasswordConfirmed, string UserType)
    {
    }
}