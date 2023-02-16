using PaintIn3D;
using Scripts.Level.Manager;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class WalkersParticalController : MonoBehaviour
    {
        [SerializeField]
        private new ParticleSystem particleSystem;

        [SerializeField]
        private new Renderer renderer;

        [SerializeField]
        private P3dPaintDecal p3DPaintDecal;

        [SerializeField]
        private WalkersManager walkersManager;

        private bool _isCheck;

        internal void InitPartical()
        {
            ChecksParticalActivities();
        }
        public void ActiveChecking()
        {
            _isCheck = true;
        }

        public void DeactiveChecking()
        {
            _isCheck = false;
        }

        private async void ChecksParticalActivities()
        {
            while (_isCheck)
            {
                await Task.Delay(16);

                if (!particleSystem.IsAlive())
                {
                    if (!gameObject.activeInHierarchy) return;
                    break;
                }
            }
            if (!gameObject.activeInHierarchy) return;
            walkersManager.FinishPartical();

        }
        public void PlayExplotionPartical()
        {
            particleSystem.Play();
        }

        public void ChangeParticalColor(Color color)
        {
            p3DPaintDecal.Color = color;

            renderer.material.color = color;
        }

        internal void ResetPartical()
        {
            
        }
    }
}