using Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class WeaponAttackController : MonoBehaviour, IPullObject
    {
        [SerializeField]
        private WeaponManager weaponManager;

        private int _currentBulletAmountInClip;

        private int _fireRate;

        private AmmoShopData _ammoShopData;

        private FireRateShopData _fireRateShopData;
        private bool status;

        public void SetData(AmmoShopData ammoShopData, FireRateShopData fireRateShopData)
        {
            _ammoShopData = ammoShopData;

            _fireRateShopData = fireRateShopData;

            _currentBulletAmountInClip = ammoShopData.AmmoCount;

            _fireRate = fireRateShopData.FireRate;
        }

        public void EnableToFire()
        {
            SwitchWeaponSafety();
            status = true;
        }

        public void DisableToFire()
        {
            status = false;
        }

        internal void AimTo()
        {
            SwitchWeaponSafety();
        }

        private async void SwitchWeaponSafety()
        {
            while (status)
            {
                await Task.Delay(_fireRate);

                PullTheTrigger();
            }
        }

        private void PullTheTrigger()
        {
            if (0 < _currentBulletAmountInClip)
            {
                _currentBulletAmountInClip--;

                SpawnBulletOnWeaponBarrel();

                weaponManager.OnPullTheWeaponTrigger(_currentBulletAmountInClip);
            }
            else
            {
                ReloadClip();
            }
        }

        private void SpawnBulletOnWeaponBarrel()
        {
            GameObject bulletObject = PullFromPool(PoolObjectType.PaintBall);

            if (bulletObject == null) return;

            bulletObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }

        private async void ReloadClip()
        {
            await Task.Delay(2000);

            _currentBulletAmountInClip = _ammoShopData.AmmoCount;

            CheckFireRate();
        }

        private void CheckFireRate()
        {
            _fireRate = _fireRateShopData.FireRate;

            weaponManager.UpdateData();
        }

        public Transform GetBarrelTransform()
        {
            return transform;
        }

        internal void ResetAtack()
        {
            _currentBulletAmountInClip = 0;

            weaponManager.OnPullTheWeaponTrigger(_currentBulletAmountInClip);
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}