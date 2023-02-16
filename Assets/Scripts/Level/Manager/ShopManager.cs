using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Signals;
using Signals;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class ShopManager : MonoBehaviour
    {
        private const string _dataPath = "Data/Cd_Shopdata";

        [SerializeField]
        private ShopIncomeController shopIncomeController;

        [SerializeField]
        private ShopWalkersController shopWalkersController;

        [SerializeField]
        private ShopFireRateController shopFireRateController;

        [SerializeField]
        private ShopAmmoController shopAmmoController;

        private int _currentMoney;

        private ShopData _shopData;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _shopData = GetData();
        }

        private ShopData GetData() => Resources.Load<Cd_ShopData>(_dataPath).ShopData;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onGetShopData += OnGetShopData;
            ShopSignals.Instance.onPressInComeButton += OnPressInComeButton;
            ShopSignals.Instance.onPressWalkersButton += OnPressWalkersButton;
            ShopSignals.Instance.onPressFireRateButton += OnPressFireRateButton;
            ShopSignals.Instance.onPressAmmoButton += OnPressAmmoButton;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onGetShopData -= OnGetShopData;
            ShopSignals.Instance.onPressInComeButton -= OnPressInComeButton;
            ShopSignals.Instance.onPressWalkersButton -= OnPressWalkersButton;
            ShopSignals.Instance.onPressFireRateButton -= OnPressFireRateButton;
            ShopSignals.Instance.onPressAmmoButton -= OnPressAmmoButton;
        }

        private void OnDisable() => UnsubscribeEvents();

        internal void OnBuyShopElement(int price)
        {
            ScoreSignals.Instance.onScoreUpdate?.Invoke(-price);
        }

        private void OnPressInComeButton()
        {
            shopIncomeController.SetData(_shopData.InComeLevel, _shopData.InCome);
            CheckCurrentMoney();
            shopIncomeController.EnterToShop(_currentMoney);
        }

        private void OnPressWalkersButton()
        {
            shopWalkersController.SetData(_shopData.WalkersLevel, _shopData.Walkers);
            CheckCurrentMoney();
            shopWalkersController.EnterToShop(_currentMoney);
        }

        private void OnPressFireRateButton()
        {
            shopFireRateController.SetData(_shopData.FireRateLevel, _shopData.FireRate);
            CheckCurrentMoney();
            shopFireRateController.EnterToShop(_currentMoney);
        }

        private void OnPressAmmoButton()
        {
            shopAmmoController.SetData(_shopData.AmmoLevel, _shopData.Ammo);
            CheckCurrentMoney();
            shopAmmoController.EnterToShop(_currentMoney);
        }

        private void CheckCurrentMoney()
        {
            _currentMoney = ScoreSignals.Instance.onGetCurrentMoney.Invoke();
        }

        internal void IncreaseIncomeLevel()
        {
            GetData().InComeLevel++;
        }

        internal void IncreaseFireRateLevel()
        {
            GetData().FireRateLevel++;
        }

        internal void IncreaseAmmoLevel()
        {
            GetData().AmmoLevel++;
        }

        private ShopData OnGetShopData()
        {
            return _shopData;
        }
    }
}