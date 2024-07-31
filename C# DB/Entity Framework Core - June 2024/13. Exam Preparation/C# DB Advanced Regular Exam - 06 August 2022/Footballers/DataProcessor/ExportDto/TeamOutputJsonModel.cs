namespace Footballers.DataProcessor.ExportDto
{
    public class TeamOutputJsonModel
    {
        public string Name { get; set; } = null!;

        public virtual FootballerOutputJsonModel[] Footballers { get; set; }
    }
}