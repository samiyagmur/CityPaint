using Data.ValueObject;
using Scripts.Level.Controller;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Signals;
using Signals;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField]
        private WeaponMovementController weaponMovementController;

        [SerializeField]
        private WeaponAttackController weaponAttackController;

        private ShopData _shopData;

        private LevelDatas _levelData;

        private void OnLevelInitilize()
        {
            Init();
            SetData();
            ActivateWeapon();
        }

        private void Init()
        {
            _shopData = CoreGameSignals.Instance.onGetShopData?.Invoke();

            _levelData = GetLevelData();
        }

        private void SetData()
        {
            weaponMovementController.SetData(_levelData.WeaponData.WeaponMovementData);

            weaponAttackController.SetData(_shopData.Ammo[_shopData.AmmoLevel], _shopData.FireRate[_shopData.FireRateLevel]);
        }

        private LevelDatas GetLevelData() => CoreGameSignals.Instance.onGetLevelData?.Invoke();

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onDrag += OnDragMouse;
            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onReset += OnReset;
            WeaponSignals.Instance.onGeneratePaintBall += OnGeneratePaintBall;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onDrag -= OnDragMouse;
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onReset -= OnReset;
            WeaponSignals.Instance.onGeneratePaintBall -= OnGeneratePaintBall;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnReset()
        {
            DeactivateWeapon();

            weaponAttackController.ResetAtack();

            weaponMovementController.ResetMovement();
        }

        private void ActivateWeapon()
        {
            weaponMovementController.SetStartDirection();

            weaponMovementController.EnableToMove();

            weaponAttackController.EnableToFire();

            weaponAttackController.AimTo();
        }

        private void DeactivateWeapon()
        {
            weaponMovementController.DisableMovement();

            weaponAttackController.DisableToFire();
        }

        internal void UpdateData()
        {
            SetData();
        }

        private void OnDragMouse(Vector3 mouseHitPosition)
        {
            weaponMovementController.FollowMousePos(mouseHitPosition);
        }

        internal void OnPullTheWeaponTrigger(int currentBulletAmountInClip)
        {
            CoreGameSignals.Instance.onPullTheWeaponTrigger?.Invoke(currentBulletAmountInClip);

            AudioSignals.Instance.onPullTheWeaponTrigger?.Invoke();
        }

        private Transform OnGeneratePaintBall()
        {
            return weaponAttackController.GetBarrelTransform();
        }
    }
}