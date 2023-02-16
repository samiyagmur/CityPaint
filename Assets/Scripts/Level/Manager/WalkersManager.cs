using Data.ValueObject;
using Interfaces;
using Scripts.Level.Controller;
using Signals;
using System;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class WalkersManager : MonoBehaviour, IPushObject
    {
        [SerializeField]
        private WalkersMovementController walkersMovementController;

        [SerializeField]
        private WalkersPhysicController walkersPhysicController;

        [SerializeField]
        private WalkersAnimationController walkersAnimationController;

        [SerializeField]
        private WalkesMeshController walkesMeshController;

        [SerializeField]
        private WalkersParticalController walkersParticalController;

        [SerializeField]
        private WalkersSettingController walkersSettingController;

        private bool _isCheck;

        private void Init()
        {
            walkersMovementController.SetData(GetLevelData().WalkersData.WalkersMovementData);
            walkersSettingController.SetData(GetLevelData().WalkersData);
            walkesMeshController.SetData(GetLevelData().WalkersData.WalkersMeshData);
            walkersAnimationController.SetData(GetLevelData().WalkersData.WalkersAnimationData);
        }

        private LevelDatas GetLevelData() => CoreGameSignals.Instance.onGetLevelData?.Invoke();

        private void OnEnable()
        {
            SubscribeEvents();

            Init();

            InitilizeWalkers();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            ReportHasDead();

            UnsubscribeEvents();
        }

        private void ReportHasDead()
        {
            CoreGameSignals.Instance.onDeadWalkers?.Invoke();
        }

        private void OnReset()
        {
            ResetWalkers();
        }

        private void InitilizeWalkers()
        {
            walkersSettingController.ConfigureSettings();

            walkesMeshController.InitMesh();

            walkersMovementController.EnableToMove();

            walkersMovementController.InitMovement();

            walkersAnimationController.EnableToAnimation();

            walkersAnimationController.InitAnimation();

            walkersParticalController.ActiveChecking();

        }

        internal void HitPaintBall()
        {
            walkersParticalController.ChangeParticalColor(walkesMeshController.GetWalkersColour());

            walkersParticalController.PlayExplotionPartical();


            walkersParticalController.InitPartical();

            walkesMeshController.DisableMesh();
        }

        internal void FinishPartical()
        {
            walkesMeshController.EnableMesh();

            PushToPool(PoolObjectType.Walker, gameObject);
        }

        private void ResetWalkers()
        {
            walkersMovementController.DisableToMove();

            walkersAnimationController.DisableToAnimation();

            walkersParticalController.DeactiveChecking();

            walkersParticalController.ResetPartical();

            PushToPool(PoolObjectType.Walker, gameObject);
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}