using System.Collections.Generic;

namespace PetStore.Web.ViewModels.Product
{
    public class AllProductsViewModel
    {
        public ICollection<ListAllProductViewModel> AllProducts { get; set; }

        public ICollection<string> Categories { get; set; }

        public string SearchQuery { get; set; }
    }
}