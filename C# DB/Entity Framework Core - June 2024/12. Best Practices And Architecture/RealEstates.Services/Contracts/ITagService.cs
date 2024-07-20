namespace RealEstates.Services.Contracts
{
    public interface ITagService
    {
        void Add(string name, int? importance = null);

        void BulkTagToProperties();
    }
}