using Controller;
using Data.ValueObject;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Signals;
using Signals;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Type;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField]
        private UIPanelController uIPanelController;

        [SerializeField]
        private LevelPanelController levelPanelController;
        private LevelDatas _levelData;
        private ShopData _shopData;

        private void Init()
        {
            _levelData = GetLevelData();
            _shopData = CoreGameSignals.Instance.onGetShopData?.Invoke();
        }

        private LevelDatas GetLevelData() => CoreGameSignals.Instance.onGetLevelData?.Invoke();

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            InputSignals.Instance.onDragMouse += OnDragMouseWithInput;
            CoreGameSignals.Instance.onLevelSuccessfull += OnLevelSuccessfull;
            CoreGameSignals.Instance.onPullTheWeaponTrigger += OnPullTheWeaponTrigger;
            CoreGameSignals.Instance.onUpdateCurrentMoney += OnIncraseCurrentMoney;
            CoreGameSignals.Instance.onIncreaseDead += OnIncreaseDead;
            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            InputSignals.Instance.onDragMouse -= OnDragMouseWithInput;
            CoreGameSignals.Instance.onLevelSuccessfull -= OnLevelSuccessfull;
            CoreGameSignals.Instance.onPullTheWeaponTrigger -= OnPullTheWeaponTrigger;
            CoreGameSignals.Instance.onUpdateCurrentMoney -= OnIncraseCurrentMoney;
            CoreGameSignals.Instance.onIncreaseDead -= OnIncreaseDead;
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnOpenPanel(UIPanelType panelType) => uIPanelController.ChangePanel(panelType, true);

        internal void OnClosePanel(UIPanelType panelType) => uIPanelController.ChangePanel(panelType, false);

        private void OnLevelInitilize()
        {
            Init();

            levelPanelController.SetShopEnhancements(_shopData);

            levelPanelController.UpdateLevelImage(0, GetLevelData().levelData.countEnoughForLevelUp);

            levelPanelController.InitLevelPanel();
        }

        private void OnLevelSuccessfull()
        {
            OnOpenPanel(UIPanelType.LevelSuccesful);
        }

        internal void OnNextLevel()
        {
            OnClosePanel(UIPanelType.LevelSuccesful);
            CoreGameSignals.Instance.onNextLevel?.Invoke();
        }

        private  void OnReset()
        {
            levelPanelController.ResetLevelPanel();
        }
        private void OnDragMouseWithInput(Vector2 mousePos)
        {
            levelPanelController.FollowMousePos(mousePos);
        }

        private void OnPullTheWeaponTrigger(int bulletCount)
        {
            levelPanelController.PrintBulletCount(bulletCount);
        }

        private void UpdateShopData()
        {
            levelPanelController.SetShopEnhancements(_shopData);
        }

        private void OnIncraseCurrentMoney(int amount)
        {
            levelPanelController.InitMoneyScore(amount);
        }

        private void OnIncreaseDead(int deadCount,int enoughDeadCountForLevelUp)
        {
            levelPanelController.UpdateLevelImage(deadCount, enoughDeadCountForLevelUp);
        }

        internal void OnPressInComeButton()
        {
            ShopSignals.Instance.onPressInComeButton();
            UpdateShopData();
        }

        internal void OnPressWalkersButton()
        {
            ShopSignals.Instance.onPressWalkersButton();
            UpdateShopData();
        }

        internal void OnPressFireRateButton()
        {
            ShopSignals.Instance.onPressFireRateButton();
            UpdateShopData();
        }

        internal void OnPressAmmoButton()
        {
            ShopSignals.Instance.onPressAmmoButton();
            UpdateShopData();
        }
    }
}