using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class ShopAmmoController : MonoBehaviour
    {
        [SerializeField]
        private ShopManager shopManager;

        private AmmoShopData _ammo;

        internal void SetData(int ammoLevel, List<AmmoShopData> ammo)
        {
            _ammo = ammo[ammoLevel];
        }

        internal void EnterToShop(int currentMoney)
        {
            CheckMoneyIsEnought(currentMoney);
        }

        private void CheckMoneyIsEnought(int currentMoney)
        {
            if (currentMoney > _ammo.Price)
            {
                BuyTheIncome(_ammo.Price);
            }
        }

        private void BuyTheIncome(int price)
        {
            shopManager.OnBuyShopElement(price);

            shopManager.IncreaseAmmoLevel();
        }
    }
}