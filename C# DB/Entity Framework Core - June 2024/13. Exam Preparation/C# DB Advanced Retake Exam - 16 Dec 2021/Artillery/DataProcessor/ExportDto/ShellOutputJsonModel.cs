namespace Artillery.DataProcessor.ExportDto
{
    public class ShellOutputJsonModel
    {
        public double ShellWeight { get; set; }

        public string Caliber { get; set; } = null!;

        public GunOutputJsonModel[] Guns { get; set; }
    }
}