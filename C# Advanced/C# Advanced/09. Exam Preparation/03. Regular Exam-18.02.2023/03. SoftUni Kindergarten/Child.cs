using System.Text;

namespace SoftUniKindergarten
{
    public class Child
    {
        private string firstName;
        private string lastName;
        private int age;
        private string parentName;
        private string contactNumber;

        public Child(string firstName, string lastName, int age, string parentName, string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ParentName = parentName;
            ContactNumber = contactNumber;
        }

        public string FirstName
        {
            get => firstName;
            private set { firstName = value; }
        }

        public string LastName
        {
            get => lastName;
            private set { lastName = value; }
        }

        public int Age
        {
            get => age;
            private set { age = value; }
        }
        public string ParentName
        {
            get => parentName;
            private set { parentName = value; }
        }


        public string ContactNumber
        {
            get => contactNumber;
            private set { contactNumber = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Child: {this.FirstName} {this.LastName}, Age: {this.Age}, Contact info: {this.ParentName} - {this.ContactNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
