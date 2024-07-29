namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(CreatorInputXmlModel[]), new XmlRootAttribute("Creators"));
            var stringReader = new StringReader(xmlString);
            var creators = (CreatorInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validCreators = new HashSet<Creator>();

            foreach (var currentCreator in creators)
            {
                if (!IsValid(currentCreator))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator
                {
                    FirstName = currentCreator.FirstName,
                    LastName = currentCreator.LastName,
                };

                foreach (var currentBoardgame in currentCreator.Boardgames)
                {
                    if (!IsValid(currentBoardgame))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame
                    {
                        Name = currentBoardgame.Name,
                        Rating = (double)currentBoardgame.Rating,
                        YearPublished = currentBoardgame.YearPublished,
                        CategoryType = (CategoryType)currentBoardgame.CategoryType,
                        Mechanics = currentBoardgame.Mechanics,
                        CreatorId = creator.Id,
                    };

                    creator.Boardgames.Add(boardgame);
                }

                validCreators.Add(creator);
                output.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var output = new StringBuilder();
            var sellers = JsonConvert.DeserializeObject<SellerInputJsonModel[]>(jsonString);
            var validSellers = new HashSet<Seller>();

            foreach (var currentSeller in sellers)
            {
                if (!IsValid(currentSeller))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller
                {
                    Name = currentSeller.Name,
                    Address = currentSeller.Address,
                    Country = currentSeller.Country,
                    Website = currentSeller.Website,
                };

                foreach (var currentBoardgameId in currentSeller.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(x => x.Id == currentBoardgameId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    seller.BoardgamesSellers.Add(new BoardgameSeller
                    {
                        BoardgameId = currentBoardgameId,
                        Seller = seller,
                    });
                }

                validSellers.Add(seller);
                output.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
