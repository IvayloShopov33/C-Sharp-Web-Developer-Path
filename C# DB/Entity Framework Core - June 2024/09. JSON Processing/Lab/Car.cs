namespace JsonDemo
{
    public class Car
    {
        public string Model { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public List<string> Extras { get; set; }

        public Engine Engine { get; set; }

        public override string ToString()
        {
            return $"{this.Vendor} {this.Model} ${this.Price:f2}, Extras: {string.Join(", ", this.Extras)}, HorsePower: {this.Engine.HorsePower}, Volume: {this.Engine.Volume}";
        }
    }
}