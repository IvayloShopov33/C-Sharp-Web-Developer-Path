namespace Equality_Logic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;

            if (person == null)
            {
                return false;
            }

            return this.Name == person.Name && this.Age == person.Age;
        }

        public override int GetHashCode()
        {
            int hashCode = this.Name.GetHashCode() + this.Age.GetHashCode();

            return hashCode;
        }
    }
}
