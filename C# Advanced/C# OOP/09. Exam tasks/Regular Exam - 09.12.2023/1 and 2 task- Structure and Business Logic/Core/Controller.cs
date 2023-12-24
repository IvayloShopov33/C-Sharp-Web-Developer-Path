using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.Divers;
using NauticalCatchChallenge.Models.Fishes;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers = new DiverRepository();
        private IRepository<IFish> fishes = new FishRepository();

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (!this.divers.Models.Any(x => x.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNotFound, this.divers.GetType().Name, diverName);
            }

            if (!this.fishes.Models.Any(x => x.Name == fishName))
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = this.divers.GetModel(diverName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diver.Name);
            }

            IFish fish = this.fishes.GetModel(fishName);

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel <= 0)
                {
                    diver.UpdateHealthStatus();
                }

                return string.Format(OutputMessages.DiverMisses, diver.Name, fish.Name);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    diver.UpdateHealthStatus();

                    return string.Format(OutputMessages.DiverHitsFish, diver.Name, fish.Points, fish.Name);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);

                    if (diver.OxygenLevel <= 0)
                    {
                        diver.UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverMisses, diver.Name, fish.Name);
                }
            }
            else
            {
                diver.Hit(fish);

                return string.Format(OutputMessages.DiverHitsFish, diver.Name, fish.Points, fish.Name);
            }
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (IDiver diver in this.divers.Models.OrderByDescending(x => x.CompetitionPoints).ThenByDescending(x => x.Catch.Count)
                .ThenBy(x => x.Name).Where(x => !x.HasHealthIssues))
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != "FreeDiver" && diverType != "ScubaDiver")
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (this.divers.Models.Any(x => x.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, this.divers.GetType().Name);
            }

            IDiver diver = null;

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                diver = new ScubaDiver(diverName);
            }

            this.divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diver.Name, this.divers.GetType().Name);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();
            IDiver diver = this.divers.GetModel(diverName);
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (string fishName in diver.Catch)
            {
                IFish fish = this.fishes.GetModel(fishName);
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            int count = 0;
            foreach (IDiver diver in this.divers.Models.Where(x => x.HasHealthIssues))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                count++;
            }

            return string.Format(OutputMessages.DiversRecovered, count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != "ReefFish" && fishType != "DeepSeaFish" && fishType != "PredatoryFish")
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (this.fishes.Models.Any(x => x.Name == fishName))
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, this.fishes.GetType().Name);
            }

            IFish fish = null;

            if (fishType == "ReefFish")
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == "DeepSeaFish")
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else
            {
                fish = new PredatoryFish(fishName, points);
            }

            this.fishes.AddModel(fish);

            return string.Format(OutputMessages.FishCreated, fish.Name);
        }
    }
}
