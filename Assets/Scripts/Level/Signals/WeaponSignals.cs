using Extantions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Level.Signals
{
    public class WeaponSignals : MonoSingleton<WeaponSignals>
    {
        public Func<Transform> onGeneratePaintBall = delegate { return null; };
    }
}