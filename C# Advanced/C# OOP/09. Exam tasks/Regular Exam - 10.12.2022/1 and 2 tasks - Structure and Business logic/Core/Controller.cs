using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(this.booths.Models.Count + 1, capacity);
            this.booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = null;
            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, cocktail.Size, cocktail.Name, cocktail.GetType().Name);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            double boothBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {boothBill:f2} lv");
            sb.AppendLine($"Booth {booth.BoothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = this.booths.Models
                .Where(x => !x.IsReserved && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            string[] orderDetails = order.Split('/');
            string itemTypeName = orderDetails[0];
            string itemName = orderDetails[1];
            int countOfOrderedPieces = int.Parse(orderDetails[2]);
            string size = string.Empty;
            bool isCocktail = false;

            if (orderDetails.Length == 4)
            {
                isCocktail = true;
                size = orderDetails[3];
            }

            if (itemTypeName != "Gingerbread" && itemTypeName != "Stolen" &&
                itemTypeName != "MulledWine" && itemTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (isCocktail)
            {
                if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                if (!booth.CocktailMenu.Models.Any(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                ICocktail cocktail = booth.CocktailMenu.Models.First(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size);
                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, cocktail.Name);
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                if (!booth.DelicacyMenu.Models.Any(x => x.GetType().Name == itemTypeName && x.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                IDelicacy delicacy = booth.DelicacyMenu.Models.First(x => x.GetType().Name == itemTypeName && x.Name == itemName);
                booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, delicacy.Name);
            }
        }
    }
}
