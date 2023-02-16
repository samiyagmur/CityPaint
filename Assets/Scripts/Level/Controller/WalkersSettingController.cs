using Scripts.Level.Data.ValueObject;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Level.Controller
{
    public class WalkersSettingController : MonoBehaviour
    {
        private WalkersData _WalkersData;

        [SerializeField]
        private NavMeshAgent navMeshAgent;

        internal void SetData(WalkersData WalkersData)
        {
            _WalkersData = WalkersData;
        }

        internal void ConfigureSettings()
        {
            navMeshAgent.speed = _WalkersData.WalkersMovementData.MovementSpeed;
        }
    }
}