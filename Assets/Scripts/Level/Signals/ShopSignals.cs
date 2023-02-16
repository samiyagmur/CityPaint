using Extantions;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.Level.Signals
{
    public class ShopSignals : MonoSingleton<ShopSignals>
    {
        public UnityAction onPressInComeButton = delegate { };
        public UnityAction onPressWalkersButton = delegate { };
        public UnityAction onPressFireRateButton = delegate { };
        public UnityAction onPressAmmoButton = delegate { };
    }
}