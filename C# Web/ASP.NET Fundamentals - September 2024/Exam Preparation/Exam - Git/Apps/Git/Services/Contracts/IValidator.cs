using System.Collections.Generic;

using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;

namespace Git.Services.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> ValidateUser(RegisterUserFormModel model);

        IEnumerable<string> ValidateRepository(CreateRepositoryFormModel model);

        IEnumerable<string> ValidateCommit(CreateCommitFormModel model);
    }
}