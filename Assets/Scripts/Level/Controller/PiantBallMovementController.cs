using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PiantBallMovementController : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody rigidbody;

        private PaintBallMovementData _paintBallMovementData;

        private Transform _barrelTransform;

        internal void SetData(PaintBallMovementData paintBallMovementData)
        {
            _paintBallMovementData = paintBallMovementData;
        }

        internal void SetBarrelTransform(Transform barrelTransform)
        {
            _barrelTransform = barrelTransform;
        }

        internal void EnableMove()
        {
            SwitchBallMovementStatus(true);
        }

        internal void DisableMove()
        {
            SwitchBallMovementStatus(false);
        }

        private void SwitchBallMovementStatus(bool isMove)
        {
            if (isMove)
            {
                rigidbody.AddForce(_barrelTransform.forward * _paintBallMovementData.Speed, ForceMode.Impulse);
            }
        }
    }
}