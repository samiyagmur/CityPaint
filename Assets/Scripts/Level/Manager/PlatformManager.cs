using Data.ValueObject;
using Scripts.Level.Controller;
using Signals;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField]
        private PlatformMovementController platformaMovementController;

        [SerializeField]
        private PlatformMeshController platformMeshController;

        private void OnLevelInitilize()
        {
            Init();

            platformaMovementController.EnableToMove();
        }

        private void Init()
        {
            platformaMovementController.SetData(GetLevelData().PlatformData.PlatformMovementData);

            platformMeshController.SetData(GetLevelData().PlatformData.PlatformMeshData);

            GetLevelData();
        }

        private LevelDatas GetLevelData() => CoreGameSignals.Instance.onGetLevelData?.Invoke();

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnReset()
        {
            platformaMovementController.DisableMovement();

            platformMeshController.ResetColor();
        }
    }
}