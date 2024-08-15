using PetStore.Services.Mapping;

namespace PetStore.Web.ViewModels.Product
{
    public class ListAllProductViewModel : IMapFrom<PetStore.Data.Models.Product>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string CategoryName { get; set; }
    }
}