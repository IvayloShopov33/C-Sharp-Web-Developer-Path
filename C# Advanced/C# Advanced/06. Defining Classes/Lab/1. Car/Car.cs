namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public bool CheckIfTheYearIsValid()
        {
            if (Year >= 1886)
            {
                return true;
            }

            return false;
        }
    }
}
