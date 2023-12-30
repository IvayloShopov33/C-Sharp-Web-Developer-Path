using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> peaks;
        private IRepository<IClimber> climbers;
        private IBaseCamp baseCamp;

        public Controller()
        {
            this.peaks = new PeakRepository();
            this.climbers = new ClimberRepository();
            this.baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak peak = this.peaks.Get(name);

            if (peak != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, peak.Name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            IPeak newPeak = new Peak(name, elevation, difficultyLevel);
            this.peaks.Add(newPeak);

            return string.Format(OutputMessages.PeakIsAllowed, newPeak.Name, this.peaks.GetType().Name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = this.climbers.Get(climberName);
            IPeak peak = this.peaks.Get(peakName);

            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (peak == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!this.baseCamp.Residents.Contains(climber.Name))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climber.Name, peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == nameof(NaturalClimber))
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climber.Name, peak.Name);
            }

            this.baseCamp.LeaveCamp(climber.Name);
            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climber.Name);
            }
            else
            {
                this.baseCamp.ArriveAtCamp(climber.Name);

                return string.Format(OutputMessages.SuccessfulAttack, climber.Name, peak.Name);
            }
        }

        public string BaseCampReport()
        {
            if (this.baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BaseCamp residents:");

                foreach (string resident in this.baseCamp.Residents)
                {
                    IClimber climber = this.climbers.Get(resident);
                    sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
                }

                return sb.ToString().TrimEnd();
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!this.baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = this.climbers.Get(climberName);

            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climber.Name);
            }
            else
            {
                climber.Rest(daysToRecover);

                return string.Format(OutputMessages.ClimberRecovered, climber.Name, daysToRecover);
            }
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber climber = this.climbers.Get(name);

            if (climber != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, climber.Name, this.climbers.GetType().Name);
            }

            IClimber newClimber = null;

            if (isOxygenUsed)
            {
                newClimber = new OxygenClimber(name);
            }
            else
            {
                newClimber = new NaturalClimber(name);
            }

            this.climbers.Add(newClimber);
            this.baseCamp.ArriveAtCamp(newClimber.Name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, newClimber.Name);
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            foreach (IClimber climber in this.climbers.All.OrderByDescending(x=>x.ConqueredPeaks.Count).ThenBy(x=>x.Name))
            {
                sb.AppendLine(climber.ToString());

                foreach (IPeak peak in this.peaks.All.OrderByDescending(x=>x.Elevation))
                {
                    if (climber.ConqueredPeaks.Contains(peak.Name))
                    {
                        sb.AppendLine(peak.ToString());
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
