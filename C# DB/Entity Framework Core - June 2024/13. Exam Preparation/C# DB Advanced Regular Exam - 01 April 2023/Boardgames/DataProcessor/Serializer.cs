namespace Boardgames.DataProcessor
{
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creatorsWithTheirBoardgames = context.Creators
                .Where(x => x.Boardgames.Count > 0)
                .OrderByDescending(x => x.Boardgames.Count)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new CreatorOutputXmlModel
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    Boardgames = x.Boardgames
                        .Select(y => new BoardgameOutputXmlModel
                        {
                            Name = y.Name,
                            YearPublished = y.YearPublished,
                        })
                        .OrderBy(y => y.Name)
                        .ToArray(),
                    BoardgamesCount = x.Boardgames.Count
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CreatorOutputXmlModel[]), new XmlRootAttribute("Creators"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(stringWriter, creatorsWithTheirBoardgames, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellersWithMostBoardgames = context.Sellers
                .Where(x => x.BoardgamesSellers
                    .Any(y => y.Boardgame.YearPublished >= year && y.Boardgame.Rating <= rating))
                .Select(x => new SellerOutputJsonModel
                {
                    Name = x.Name,
                    Website = x.Website,
                    Boardgames = x.BoardgamesSellers
                        .Where(y => y.Boardgame.YearPublished >= year && y.Boardgame.Rating <= rating)
                        .Select(y => new BoardgameOutputJsonModel
                        {
                            Name = y.Boardgame.Name,
                            Rating = y.Boardgame.Rating,
                            Mechanics = y.Boardgame.Mechanics,
                            Category = y.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(y => y.Rating)
                        .ThenBy(y => y.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Boardgames.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellersWithMostBoardgames, Formatting.Indented);
        }
    }
}