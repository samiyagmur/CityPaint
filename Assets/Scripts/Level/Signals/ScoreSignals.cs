using Extantions;
using System;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction<int> onScoreUpdate = delegate { };

        public Func<int> onGetCurrentMoney = delegate { return 0; };
    }
}