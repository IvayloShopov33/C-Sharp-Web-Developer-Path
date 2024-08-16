using System.Text;

namespace _08._Car_Salesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(this.Model + ":");
            output.AppendLine($"  {this.Engine.Model}:");
            output.AppendLine($"    Power: {this.Engine.Power}");

            if (this.Engine.Displacement != 0)
            {
                output.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }
            else
            {
                output.AppendLine($"    Displacement: n/a");
            }

            if (this.Engine.Efficiency != null)
            {
                output.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }
            else
            {
                output.AppendLine($"    Efficiency: n/a");
            }

            if (this.Weight != 0)
            {
                output.AppendLine($"  Weight: {this.Weight}");
            }
            else
            {
                output.AppendLine($"  Weight: n/a");
            }

            if (this.Color != null)
            {
                output.Append($"  Color: {this.Color}");
            }
            else
            {
                output.Append($"  Color: n/a");
            }

            return output.ToString();
        }
    }
}
