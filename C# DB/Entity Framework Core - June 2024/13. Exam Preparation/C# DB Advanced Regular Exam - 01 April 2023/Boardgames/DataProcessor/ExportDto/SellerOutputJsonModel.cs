namespace Boardgames.DataProcessor.ExportDto
{
    public class SellerOutputJsonModel
    {
        public string Name { get; set; } = null!;

        public string Website { get; set; } = null!;

        public BoardgameOutputJsonModel[] Boardgames { get; set; } = null!;
    }
}