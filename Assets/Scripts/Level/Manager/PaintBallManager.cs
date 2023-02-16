using Data.ValueObject;
using Interfaces;
using Scripts.Level.Controller;
using Scripts.Level.Signals;
using Signals;
using Type;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class PaintBallManager : MonoBehaviour, IPushObject
    {
        [SerializeField]
        private PiantBallMovementController piantBallMovementController;

        private void Init()
        {
            piantBallMovementController.SetData(GetLevelData().PaintBallData.PaintBallMovementData);
        }

        private LevelDatas GetLevelData() => CoreGameSignals.Instance.onGetLevelData?.Invoke();

        private void OnEnable()
        {
            SubscribeEvents();
            Init();
            EnabLeBallActivity();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            DisableBallActivity();
            UnsubscribeEvents();
        }

        private void EnabLeBallActivity()
        {
            Transform barrelTransform = WeaponSignals.Instance.onGeneratePaintBall?.Invoke();

            piantBallMovementController.SetBarrelTransform(barrelTransform);

            piantBallMovementController.EnableMove();
        }

        private void DisableBallActivity()
        {
            piantBallMovementController.DisableMove();
        }

        private void OnReset()
        {
            PushToPool(PoolObjectType.PaintBall, gameObject);
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}