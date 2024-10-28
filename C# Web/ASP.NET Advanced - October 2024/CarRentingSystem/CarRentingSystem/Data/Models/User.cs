using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static CarRentingSystem.Data.ModelsValidationConstraints;

namespace CarRentingSystem.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(UserFullNameMaxLength)]
        public string FullName { get; set; }
    }
}