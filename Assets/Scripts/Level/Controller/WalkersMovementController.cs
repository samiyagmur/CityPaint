using Scripts.Exteions;
using Scripts.Level.Data.ValueObject;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Level.Controller
{
    public class WalkersMovementController : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;

        private WalkersMovementData _WalkersMovementData;

        private WalkersData _WalkersData;

        private bool _isMoving;

        internal void SetData(WalkersMovementData WalkersMovementData)
        {
            _WalkersMovementData = WalkersMovementData;
        }

        internal void InitMovement()
        {
            SwitchPatrolingStatus();
        }
        internal void EnableToMove()
        {
            _isMoving = true;
        }

        internal void DisableToMove()
        {
            _isMoving = false;
        }

        private async void SwitchPatrolingStatus()
        {
            while (_isMoving)
            {
                await Task.Delay(3000);

                Move();
            }
        }

        private void Move()
        {
            Vector3 target = UpdateTarget();

            if (target == null) return;

            navMeshAgent.destination = target;
        }

        private Vector3 UpdateTarget()
        {
            return _WalkersMovementData.spawnSurface.GetRandomTargetOnCylinder();
        }

        internal bool MovingIsActive()
        {
            return navMeshAgent != null && !navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;
        }

    }
}