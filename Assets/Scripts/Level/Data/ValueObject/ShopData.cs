using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class ShopData
    {
        public int InComeLevel;

        public int WalkersLevel;

        public int FireRateLevel;

        public int AmmoLevel;

        [ShowInInspector]
        public List<InComeShopData> InCome = new List<InComeShopData>();

        [ShowInInspector]
        public List<WalkersShopData> Walkers = new List<WalkersShopData>();

        [ShowInInspector]
        public List<FireRateShopData> FireRate = new List<FireRateShopData>();

        [ShowInInspector]
        public List<AmmoShopData> Ammo = new List<AmmoShopData>();
    }
}