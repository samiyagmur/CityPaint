using Data.UnityObject;
using Data.ValueObject;
using Scripts.Level.Data.ValueObject;
using Signals;
using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _currentMoney;

        private ScoreData _scoreData;
        private ShopData _shopdata;

        private string _dataPath = "Data/Cd_ScoreData";

        private int _incomeRange;
        private bool _isActive;

        private void OnlevelInitilize()
        {
            GetData();
            InitData();

            _isActive = true;
            SwitchScoreActivity();
        }

        public void GetData()
        {
            _scoreData = Resources.Load<Cd_ScoreData>(_dataPath).ScoreData;

            _shopdata = CoreGameSignals.Instance.onGetShopData?.Invoke();
        }

        private void InitData()
        {
            _currentMoney = _scoreData.moneyOnSafe;

            CoreGameSignals.Instance.onUpdateCurrentMoney?.Invoke(_currentMoney);
        }

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;

            CoreGameSignals.Instance.onLevelInitilize += OnlevelInitilize;
            ScoreSignals.Instance.onScoreUpdate += OnScoreUpdate;
            ScoreSignals.Instance.onGetCurrentMoney += OnGetCurrentMoney;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onLevelInitilize += OnlevelInitilize;
            ScoreSignals.Instance.onScoreUpdate -= OnScoreUpdate;
            ScoreSignals.Instance.onGetCurrentMoney -= OnGetCurrentMoney;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnReset()
        {
            _isActive = false;
        }

        private async void SwitchScoreActivity()
        {
            while (_isActive)
            {
                CheckInComeRange();

                await Task.Delay(_incomeRange * 1000);

                _currentMoney++;

                CoreGameSignals.Instance.onUpdateCurrentMoney?.Invoke(_currentMoney);
            }
        }

        private void CheckInComeRange()
        {
            _incomeRange = _shopdata.InCome[_shopdata.InComeLevel].Range;
        }

        private void OnScoreUpdate(int cost)
        {
            _currentMoney += cost;
            CoreGameSignals.Instance.onUpdateCurrentMoney?.Invoke(_currentMoney);
        }

        private int OnGetCurrentMoney()
        {
            return _currentMoney;
        }

        // [Button]//ForTesting
        private void Save()
        {
            //_saver.UpdateSave(_scoreData);
        }

        // [Button]//ForTesting
        private void Load()
        {
            // _scoreData= _loader.UpdateLoad<ScoreData>();
        }
    }
}