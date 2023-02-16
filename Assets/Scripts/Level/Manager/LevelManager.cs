using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour//Modules
    {

        [SerializeField]
        private Transform levelholder;

        private int _levelID;

        private int _deadCount;

        private int _levelEnoughCount;

        private LevelDatas _leveData;

        private readonly string _dataPath = "Data/Cd_LevelData";

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _leveData = GetLevelData();
        }

        private LevelDatas GetLevelData() => Resources.Load<Cd_LevelData>(_dataPath).LevelData[_levelID];

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onGetLevelData += OnGetLevelData;
            CoreGameSignals.Instance.onLevelSuccessfull += OnLevelSuccessfull;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onDeadWalkers += OnDeadWalkers;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onGetLevelData -= OnGetLevelData;
            CoreGameSignals.Instance.onLevelSuccessfull -= OnLevelSuccessfull;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onDeadWalkers -= OnDeadWalkers;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void Start()
        {
            CoreGameSignals.Instance.onLevelInitilize?.Invoke();
        }
        private void OnLevelInitilize()
        {
            _deadCount = 0;
            _levelEnoughCount = _leveData.levelData.countEnoughForLevelUp;
        }

        private LevelDatas OnGetLevelData()
        {
            return _leveData;
        }

        private void OnDeadWalkers()
        {
            _deadCount++;

            CoreGameSignals.Instance.onIncreaseDead?.Invoke(_deadCount, _levelEnoughCount);

            if (_deadCount == _levelEnoughCount)
            {
                CoreGameSignals.Instance.onLevelSuccessfull?.Invoke();
            }
        }

        private void OnLevelSuccessfull()
        {
            CoreGameSignals.Instance.onReset();
        }

        private void OnNextLevel()
        {
            _levelID++;
            Init();
            CoreGameSignals.Instance.onLevelInitilize?.Invoke();
        }

        private void OnReset()
        {
            _deadCount = 0;
        }

    }
}