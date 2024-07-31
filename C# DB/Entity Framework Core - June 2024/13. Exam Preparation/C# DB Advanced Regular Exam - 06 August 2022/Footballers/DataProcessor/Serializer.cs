namespace Footballers.DataProcessor
{
    using System.Globalization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Footballers.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coachesWithTheirFootballers = context.Coaches
                .Where(x => x.Footballers.Any())
                .Select(x => new CoachOutputXmlModel
                {
                    Name = x.Name,
                    Footballers = x.Footballers
                        .Select(y => new FootballerOutputXmlModel
                        {
                            Name = y.Name,
                            PositionType = y.PositionType.ToString(),
                        })
                        .OrderBy(y => y.Name)
                        .ToArray(),
                    FootballersCount = x.Footballers.Count,
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.Name)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CoachOutputXmlModel[]), new XmlRootAttribute("Coaches"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, coachesWithTheirFootballers, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithMostFootballersWithContractsAfterGivenDate = context.Teams
                .Where(x => x.TeamsFootballers.Any(y => DateTime.Compare(y.Footballer.ContractStartDate, date) >= 0))
                .Select(x => new TeamOutputJsonModel
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers
                        .Where(y => DateTime.Compare(y.Footballer.ContractStartDate, date) >= 0)
                        .OrderByDescending(y => y.Footballer.ContractEndDate)
                        .ThenBy(y => y.Footballer.Name)
                        .Select(y => new FootballerOutputJsonModel
                        {
                            Name = y.Footballer.Name,
                            ContractStartDate = y.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = y.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = y.Footballer.BestSkillType.ToString(),
                            PositionType = y.Footballer.PositionType.ToString(),
                        })
                        .ToArray(),
                })
                .OrderByDescending(x => x.Footballers.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teamsWithMostFootballersWithContractsAfterGivenDate, Formatting.Indented);
        }
    }
}
