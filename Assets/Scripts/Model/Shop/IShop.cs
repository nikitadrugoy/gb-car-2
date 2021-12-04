using System;
using Tools.Tools;

namespace Model.Shop
{
    public interface IShop
    {
        void Buy(string id);
        string GetCost(string productID);
        void RestorePurchase();
        event Action OnSuccessPurchase;
        event Action OnFailedPurchase;
    }
}