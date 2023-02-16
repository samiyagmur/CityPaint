using Data.ValueObject;
using Scripts.Level.Controller;
using Signals;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class WalkersGenerateManager : MonoBehaviour
    {
        [SerializeField]
        private WalkersGenerateController walkersGenerateController;

        private void OnLevelInitilize()
        {
            Init();

            walkersGenerateController.EnableToGenerate();
        }

        private void Init()
        {
            walkersGenerateController.SetData(GetLevelData().WalkersData.WalkersGanarateData);
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
            walkersGenerateController.DisableGenerate();

            walkersGenerateController.ResetGenerate();
        }
    }
}