using Boardgames.Data.Models.Enums;

namespace Boardgames.Data
{
    public static class ModelsValidationConstraints
    {
        // Boardgame
        public const byte BoardgameNameMinLength = 10;
        public const byte BoardgameNameMaxLength = 20;
        public const string BoardgameRatingMinValue = "1.00";
        public const string BoardgameRatingMaxValue = "10.00";
        public const int BoardgameYearPublishedMinValue = 2018;
        public const int BoardgameYearPublishedMaxValue = 2023;
        public const int BoardgameCategoryTypeMinValue = (int)CategoryType.Abstract;
        public const int BoardgameCategoryTypeMaxValue = (int)CategoryType.Strategy;

        // Seller
        public const byte SellerNameMinLength = 5;
        public const byte SellerNameMaxLength = 20;
        public const byte SellerAddressMinLength = 2;
        public const byte SellerAddressMaxLength = 30;
        public const string SellerWebsiteRegEx = @"^www.[A-Za-z0-9-]*.com$";

        // Creator
        public const byte CreatorFirstNameMinLength = 2;
        public const byte CreatorFirstNameMaxLength = 7;
        public const byte CreatorLastNameMinLength = 2;
        public const byte CreatorLastNameMaxLength = 7;
    }
}