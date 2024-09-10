namespace Git.Data
{
    public static class ModelsValidationConstraints
    {
        public const byte IdMaxLength = 70;

        // User
        public const byte UsernameMinLength = 5;
        public const byte UsernameMaxLength = 20;
        public const byte UserPasswordMinLength = 6;
        public const byte UserPasswordMaxLength = 20;

        // Repository
        public const byte RepositoryNameMinLength = 3;
        public const byte RepositoryNameMaxLength = 10;
        public const string RepositoryTypePublic = "Public";
        public const string RepositoryTypePrivate = "Private";

        // Commit
        public const byte CommitDescriptionMinLength = 5;
    }
}