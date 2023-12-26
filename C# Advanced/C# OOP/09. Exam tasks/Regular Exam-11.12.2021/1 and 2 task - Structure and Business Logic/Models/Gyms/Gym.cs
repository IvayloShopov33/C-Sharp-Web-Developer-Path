using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.Equipment.Select(x => x.Weight).Sum();

        public ICollection<IEquipment> Equipment { get; private set; }

        public ICollection<IAthlete> Athletes { get; private set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            text.Append("Athletes: ");

            if (this.Athletes.Count == 0)
            {
                text.AppendLine("No athletes");
            }
            else
            {
                text.AppendLine(string.Join(", ", this.Athletes.Select(x => x.FullName)));
            }

            text.AppendLine($"Equipment total count: {this.Equipment.Count}");
            text.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return text.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }
    }
}
