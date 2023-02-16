using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlatformMovementController : MonoBehaviour
    {
        private PlatformMovementData _platformMovementData;

        private bool _isRotate;

        internal void SetData(PlatformMovementData platformMovementData)
        {
            _platformMovementData = platformMovementData;
        }

        private void Update()
        {
            if (_isRotate)
            {
                transform.Rotate(Vector3.down, _platformMovementData.RotateSpeed * Time.deltaTime);
            }
        }

        internal void EnableToMove()
        {
            _isRotate = true;
        }

        internal void DisableMovement()
        {
            _isRotate = false;
        }
    }
}