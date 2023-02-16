using Scripts.Helper.Interfaces;
using Scripts.Level.Manager;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class WalkersPhysicController : MonoBehaviour
    {
        [SerializeField]
        private WalkersManager walkersManager;

        [System.Obsolete]
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.other.TryGetComponent(out IDamager damager))
            {
                walkersManager.HitPaintBall();
            }
        }
    }
}