using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_ShopData", menuName = "Data/ShopData")]
    public class Cd_ShopData : ScriptableObject
    {
        public ShopData ShopData;

        private const string Key = "shopData";

        private const string uniqID = "2";

        public string GetKey()
        {
            return Key;
        }
    }
}