using CarShop.Models.Cars;
using CarShop.Models.Issues;
using CarShop.Models.Users;

namespace CarShop.Services.Contracts
{
    public interface IValidator
    {
        ICollection<string> ValidateUserRegistration(RegisterUserFormModel model);

        ICollection<string> ValidateCarAddition(AddCarFormModel model);

        ICollection<string> ValidateIssueAddition(AddIssueFormModel model);
    }
}