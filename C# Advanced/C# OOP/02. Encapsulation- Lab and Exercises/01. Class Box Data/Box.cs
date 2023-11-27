namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 2 * (this.Length + this.Width) * this.Height + 2 * (this.Length * this.Width);

            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 2 * (this.Length + this.Width) * this.Height;

            return result;
        }

        public double Volume()
        {
            double result = this.Length * this.Width * this.Height;

            return result;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():F2}{Environment.NewLine}Lateral Surface Area - {this.LateralSurfaceArea():F2}{Environment.NewLine}Volume - {this.Volume():F2}";
        }
    }
}
