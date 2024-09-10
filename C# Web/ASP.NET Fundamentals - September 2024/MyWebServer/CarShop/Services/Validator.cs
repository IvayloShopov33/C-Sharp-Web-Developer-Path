using System.Text.RegularExpressions;

using CarShop.Models.Cars;
using CarShop.Models.Issues;
using CarShop.Models.Users;
using CarShop.Services.Contracts;

using static CarShop.Data.ModelsValidationConstraints;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.UserName.Length < UserNameMinLength || model.UserName.Length > UserNameMaxLength)
            {
                errors.Add($"UserName {model.UserName} must be between {UserNameMinLength} and {UserNameMaxLength} characters long.");
            }

            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserPasswordMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} and {UserPasswordMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are not equal.");
            }

            if (model.UserType != UserTypeMechanic && model.UserType != UserTypeClient)
            {
                errors.Add($"User must be either a {UserTypeMechanic} or a {UserTypeClient}");
            }

            return errors;
        }

        public ICollection<string> ValidateCarAddition(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < CarModelMinLength || model.Model.Length > CarModelMaxLength)
            {
                errors.Add($"Car Model {model.Model} must be between {CarModelMinLength} and {CarModelMaxLength} characters long.");
            }

            if (model.Year < CarYearMinValue || model.Year > DateTime.UtcNow.Year)
            {
                errors.Add($"Car Year of Production {model.Year} must be between {CarYearMinValue} and {DateTime.UtcNow.Year}.");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image {model.Image} is not a valid URL.");
            }

            if (!Regex.IsMatch(model.PlateNumber, CarPlateNumberRegEx))
            {
                errors.Add($"Car Plate Number {model.PlateNumber} is not valid. The correct format is: AA0000AA.");  
            }

            return errors;
        }

        public ICollection<string> ValidateIssueAddition(AddIssueFormModel model)
        {
            var errors = new List<string>();

            if (model.Description.Length < IssueDescriptionMinLength)
            {
                errors.Add($"Issue Description must be at least {IssueDescriptionMinLength} characters long.");
            }

            return errors;
        }
    }
}