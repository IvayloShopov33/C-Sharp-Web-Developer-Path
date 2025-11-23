using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private List<Child> registry;
        private int capacity;
        private string name;

        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Registry = new List<Child>();
        }

        public string Name
        {
            get => name;
            private set { name = value; }
        }

        public int Capacity
        {
            get => capacity;
            private set { capacity = value; }
        }

        public List<Child> Registry
        {
            get => registry;
            private set { registry = value; }
        }

        public int ChildrenCount
        {
            get => this.Registry.Count;
        }

        public bool AddChild(Child child)
        {
            if (this.Capacity > this.Registry.Count)
            {
                this.Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            int index = childFullName.IndexOf(' ');
            string firstName = childFullName.Substring(0, index);
            string lastName = childFullName.Substring(index + 1);

            Child childToRemove = this.Registry.FirstOrDefault(x => x.FirstName == firstName);
            if (childToRemove != null)
            {
                if (childToRemove.LastName == lastName)
                {
                    this.Registry.Remove(childToRemove);
                    return true;
                }

                return false;
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            int index = childFullName.IndexOf(' ');
            string firstName = childFullName.Substring(0, index);
            string lastName = childFullName.Substring(index + 1);

            Child child = this.Registry.FirstOrDefault(x => x.FirstName == firstName);
            if (child != null)
            {
                if (child.LastName == lastName)
                {
                    return child;
                }

                return null;
            }

            return null;
        }

        public string RegistryReport()
        {
            StringBuilder output = new();
            output.AppendLine($"Registered children in {this.Name}:");

            foreach (Child child in this.Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                output.AppendLine(child.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
