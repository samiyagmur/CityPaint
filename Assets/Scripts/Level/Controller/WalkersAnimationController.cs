using Scripts.Level.Data.ValueObject;
using System;
using System.Threading.Tasks;
using Type;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Level.Controller
{
    public class WalkersAnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private int velocityHash;

        [SerializeField]
        private NavMeshAgent navMeshAgent;

        private WalkersAnimationData _walkersAnimationData;
        private bool _IsActive;

        internal void SetData(WalkersAnimationData walkersAnimationData)
        {
            _walkersAnimationData = walkersAnimationData;
        }

        internal void InitAnimation()
        {
            velocityHash = Animator.StringToHash("Velocity");

            SwitchAnimationActivateStatus();
        }
        internal void EnableToAnimation()
        {
            _IsActive=true;
        }
        internal void DisableToAnimation()
        {
            _IsActive = false;
        }

        internal async void SwitchAnimationActivateStatus()
        {
            while (_IsActive)
            {
                await Task.Delay(1);

                PlayBlendAnimation();
            }
        }


        private void PlayBlendAnimation()
        {
            float agentSpeed = navMeshAgent.velocity.magnitude;

            agentSpeed = Mathf.Clamp(agentSpeed, 0, 5);

            animator.SetFloat("Velocity", agentSpeed);
        }
    }
}