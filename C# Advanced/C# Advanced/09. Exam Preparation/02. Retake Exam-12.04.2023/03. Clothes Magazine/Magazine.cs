using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Clothes = new();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (this.Capacity > this.Clothes.Count)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color) =>
            this.Clothes.Remove(this.Clothes.FirstOrDefault(x => x.Color == color));

        public Cloth GetSmallestCloth() => this.Clothes.OrderBy(x => x.Size).FirstOrDefault();

        public Cloth GetCloth(string color) => this.Clothes.FirstOrDefault(x => x.Color == color);

        public int GetClothCount() => this.Clothes.Count;

        public string Report()
        {
            StringBuilder output = new();
            output.AppendLine($"{this.Type} magazine contains:");

            foreach (Cloth cloth in this.Clothes.OrderBy(x => x.Size))
            {
                output.AppendLine(cloth.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
