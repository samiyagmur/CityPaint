using Data.ValueObject;
using Extantions;
using Scripts.Level.Data.ValueObject;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onLevelInitilize = delegate { };

        public Func<LevelDatas> onGetLevelData = delegate { return null; };

        public UnityAction onPlay = delegate { };

        public UnityAction onLevelSuccessfull = delegate { };

        public UnityAction onClearActiveLevel = delegate { };

        public UnityAction onReset = delegate { };

        public UnityAction onNextLevel = delegate { };

        public UnityAction<Vector3> onDrag = delegate { };

        public UnityAction onDeadWalkers = delegate { };

        public UnityAction<int> onPullTheWeaponTrigger = delegate { };

        public Func<ShopData> onGetShopData = delegate { return null; };

        public UnityAction<int> onGetIncomeRange = delegate { };

        public UnityAction<int> onUpdateCurrentMoney = delegate { };

        public UnityAction<ShopData> onUpdateShopData = delegate { };

        internal UnityAction<int,int> onIncreaseDead = delegate { };
    }
}