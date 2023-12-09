namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                this.radius = value;
            }
        }

        public override double CalculatePerimeter() => 2 * radius * Math.PI;

        public override double CalculateArea() => Math.PI * Math.Pow(radius, 2);
    }
}
