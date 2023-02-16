using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class ShopIncomeController : MonoBehaviour
    {
        [SerializeField]
        private ShopManager shopManager;

        private InComeShopData _inCome;

        internal void SetData(int inComeLevel, List<InComeShopData> inCome)
        {
            _inCome = inCome[inComeLevel];
        }

        internal void EnterToShop(int currentMoney)
        {
            CheckMoneyIsEnought(currentMoney);
        }

        private void CheckMoneyIsEnought(int currentMoney)
        {
            if (currentMoney > _inCome.Price)
            {
                BuyTheIncome(_inCome.Price);
            }
        }

        private void BuyTheIncome(int price)
        {
            shopManager.OnBuyShopElement(price);

            shopManager.IncreaseIncomeLevel();
        }
    }
}