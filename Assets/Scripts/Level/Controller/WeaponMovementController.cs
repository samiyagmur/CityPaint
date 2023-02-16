using Scripts.Exteions;
using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class WeaponMovementController : MonoBehaviour
    {
        private WeaponMovementData _weaponMovementData;

        private bool _isRotate;
        private Quaternion startDirection;

        internal void SetData(WeaponMovementData weaponMovementData)
        {
            _weaponMovementData = weaponMovementData;
        }

        internal void SetStartDirection()
        {
            startDirection = transform.rotation;
        }

        internal void EnableToMove()
        {
            _isRotate = true;
        }

        internal void DisableMovement()
        {
            _isRotate = false;
        }

        internal void FollowMousePos(Vector3 mousePos)
        {
            if (_isRotate)
            {
                transform.rotation = transform.RotateAsPosition(mousePos, _weaponMovementData.rotateSpeed);
            }
        }

        internal void ResetMovement()
        {
            transform.rotation = startDirection;
        }
    }
}