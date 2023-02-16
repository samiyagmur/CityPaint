using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class ShopFireRateController : MonoBehaviour
    {
        [SerializeField]
        private ShopManager shopManager;

        private FireRateShopData _fireRate;

        internal void SetData(int fireRateLevel, List<FireRateShopData> fireRate)
        {
            _fireRate = fireRate[fireRateLevel];
        }

        internal void EnterToShop(int currentMoney)
        {
            CheckMoneyIsEnought(currentMoney);
        }

        private void CheckMoneyIsEnought(int currentMoney)
        {
            if (currentMoney > _fireRate.Price)
            {
                BuyTheIncome(_fireRate.Price);
            }
        }

        private void BuyTheIncome(int price)
        {
            shopManager.OnBuyShopElement(price);

            shopManager.IncreaseFireRateLevel();
        }
    }
}