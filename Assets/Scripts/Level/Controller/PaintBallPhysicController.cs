using Interfaces;
using Scripts.Helper.Interfaces;
using Signals;
using System;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PaintBallPhysicController : MonoBehaviour, IDamager, IPushObject
    {
        [Obsolete]
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.other.CompareTag("Platform"))
            {
                PushToPool(PoolObjectType.PaintBall, gameObject);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}