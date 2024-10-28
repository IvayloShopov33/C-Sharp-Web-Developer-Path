using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Moq;

namespace CarRentingSystem.Tests.Mocks
{
    public static class TempDataMock
    {
        public static Mock<ITempDataDictionary> Instance
        {
            get
            {
                return new Mock<ITempDataDictionary>();
            }
        }
    }
}