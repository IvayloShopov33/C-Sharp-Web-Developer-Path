namespace Footballers.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(CoachInputXmlModel[]), new XmlRootAttribute("Coaches"));
            var stringReader = new StringReader(xmlString);
            var coaches = (CoachInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validCoaches = new List<Coach>();

            foreach (var currentCoach in coaches)
            {
                if (!IsValid(currentCoach))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach
                {
                    Name = currentCoach.Name,
                    Nationality = currentCoach.Nationality,
                };

                foreach (var currentFootballer in currentCoach.Footballers)
                {
                    if (!IsValid(currentFootballer))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractStartDateValid = DateTime
                        .TryParseExact(currentFootballer.ContractStartDate, "dd/MM/yyyy", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime footballerContractStartDate);

                    bool isContractEndDateValid = DateTime
                        .TryParseExact(currentFootballer.ContractEndDate, "dd/MM/yyyy", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime footballerContractEndDate);

                    if (!isContractStartDateValid || !isContractEndDateValid ||
                        DateTime.Compare(footballerContractStartDate, footballerContractEndDate) > 0)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new Footballer
                    {
                        Name = currentFootballer.Name,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        PositionType = (PositionType)currentFootballer.PositionType,
                        BestSkillType = (BestSkillType)currentFootballer.BestSkillType,
                        CoachId = coach.Id,
                    };

                    coach.Footballers.Add(footballer);
                }

                validCoaches.Add(coach);
                output.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var output = new StringBuilder();
            var teams = JsonConvert.DeserializeObject<TeamInputJsonModel[]>(jsonString);
            var validTeams = new List<Team>();

            foreach (var currentTeam in teams)
            {
                if (!IsValid(currentTeam) || currentTeam.Trophies <= 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team
                {
                    Name = currentTeam.Name,
                    Nationality = currentTeam.Nationality,
                    Trophies = currentTeam.Trophies,
                };

                foreach (var footballerId in currentTeam.Footballers.Distinct())
                {
                    if (!context.Footballers.Any(x => x.Id == footballerId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        FootballerId = footballerId,
                        Team = team,
                    });
                }

                validTeams.Add(team);
                output.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
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
