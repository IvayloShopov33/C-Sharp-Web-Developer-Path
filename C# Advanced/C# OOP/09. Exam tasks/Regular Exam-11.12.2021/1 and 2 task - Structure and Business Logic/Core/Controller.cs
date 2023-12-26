using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment = new EquipmentRepository();
        private ICollection<IGym> gyms = new List<IGym>();

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            IGym gym = this.gyms.First(x => x.Name == gymName);

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            if (equipmentType == "BoxingGloves")
            {
                this.equipment.Add(new BoxingGloves());
            }
            else
            {
                this.equipment.Add(new Kettlebell());
            }

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym = null;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            this.gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGym gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);

            foreach (IAthlete athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
