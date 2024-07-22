namespace Cadastre.DataProcessor.ExportDtos
{
    public class PropertyOutputJsonModel
    {
        public string PropertyIdentifier { get; set; }

        public int Area { get; set; }

        public string Address { get; set; }

        public string DateOfAcquisition { get; set; }

        public List<CitizenOutputJsonModel> Owners { get; set; }
    }
}