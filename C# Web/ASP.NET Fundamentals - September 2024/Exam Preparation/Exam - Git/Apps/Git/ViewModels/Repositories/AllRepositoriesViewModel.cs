﻿namespace Git.ViewModels.Repositories
{
    public class AllRepositoriesViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OwnerUsername { get; set; }

        public string RepositoryType { get; set; }

        public string CreatedOn { get; set; }

        public int Commits { get; set; }
    }
}