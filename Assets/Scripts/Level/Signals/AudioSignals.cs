using Extantions;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class AudioSignals : MonoSingleton<AudioSignals>
    {
        public UnityAction onPullTheWeaponTrigger = delegate { };
    }
}