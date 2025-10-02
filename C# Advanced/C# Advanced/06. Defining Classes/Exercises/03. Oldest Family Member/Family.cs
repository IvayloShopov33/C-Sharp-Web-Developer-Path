namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get { return people; } set { people = value; } }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            int maximumAge = this.People.Max(p => p.Age);

            return this.People.FirstOrDefault(x => x.Age == maximumAge);
        }
    }
}