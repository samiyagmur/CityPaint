using Interfaces;
using Scripts.Exteions;
using Scripts.Level.Data.ValueObject;
using Signals;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class WalkersGenerateController : MonoBehaviour, IPullObject
    {
        private WalkersGenerateData _WalkersGanarateData;

        private int _walkersCounter;

        public void SetData(WalkersGenerateData WalkersGanarateData)
        {
            _WalkersGanarateData = WalkersGanarateData;
        }

        public void EnableToGenerate()
        {
            SwitchGenerateEngineStatus(true);
        }

        public void DisableGenerate()
        {
            SwitchGenerateEngineStatus(false);
        }

        private async void SwitchGenerateEngineStatus(bool status)
        {
            if (status)
            {
                while (_walkersCounter < _WalkersGanarateData.TotalGenerate)
                {
                    if (status)
                    {
                        await Task.Delay(5000);

                        _walkersCounter++;

                        Generate();
                    }
                }
            }
        }

        private void Generate()
        {
            Vector3 spawnPos = transform.GetRandomPointOnCylinder(_WalkersGanarateData.SpawnSurface);

            GameObject spawnedObject = PullFromPool(PoolObjectType.Walker);

            if (spawnedObject == null) return;

            spawnedObject.transform.position = spawnPos;
        }

        public void ResetGenerate()
        {
            _walkersCounter = 0;
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}