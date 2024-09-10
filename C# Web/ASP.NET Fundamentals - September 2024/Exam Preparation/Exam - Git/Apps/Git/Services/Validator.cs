using System.Collections.Generic;

using Git.Services.Contracts;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;

using static Git.Data.ModelsValidationConstraints;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public IEnumerable<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username {model.Username} must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (model.Email.Length <= 0)
            {
                errors.Add($"Email {model.Email} must be more than 0 characters long.");
            }

            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserPasswordMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} and {UserPasswordMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and Confirm Password are different.");
            }

            return errors;
        }

        public IEnumerable<string> ValidateRepository(CreateRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < RepositoryNameMinLength || model.Name.Length > RepositoryNameMaxLength)
            {
                errors.Add($"Repository Name {model.Name} must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} characters long.");
            }

            if (model.RepositoryType != RepositoryTypePublic && model.RepositoryType != RepositoryTypePrivate)
            {
                errors.Add($"Repository Type {model.RepositoryType} must be either {RepositoryTypePublic} or {RepositoryTypePrivate}.");
            }

            return errors;
        }

        public IEnumerable<string> ValidateCommit(CreateCommitFormModel model)
        {
            var errors = new List<string>();

            if (model.Description.Length < CommitDescriptionMinLength)
            {
                errors.Add($"Commit Description {model.Description} must be at least {CommitDescriptionMinLength} characters long.");
            }

            return errors;
        }
    }
}