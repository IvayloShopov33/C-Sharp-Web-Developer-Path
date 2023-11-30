namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int Radius
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

        public void Draw()
        {
            Console.Write(new string(' ', this.Radius));
            Console.WriteLine(new string('*', this.Radius * 2 + 1));
            int count = 0;
            for (int i = 2; i < this.Radius + 1; i++)
            {
                Console.Write(new string(' ', this.Radius - i));
                Console.Write("**");
                Console.Write(new string(' ', this.Radius * 2 + 1 + count));
                Console.WriteLine("**");
                count += 2;
            }

            Console.Write("*");
            Console.Write(new string(' ', this.Radius * 2 + 1 + count));
            Console.WriteLine("*");

            for (int i = this.Radius; i >= 2; i--)
            {
                Console.Write(new string(' ', this.Radius - i));
                Console.Write("**");
                count -= 2;
                Console.Write(new string(' ', this.Radius * 2 + 1 + count));
                Console.WriteLine("**");
            }

            Console.Write(new string(' ', this.Radius));
            Console.WriteLine(new string('*', this.Radius * 2 + 1));
        }
    }
}
