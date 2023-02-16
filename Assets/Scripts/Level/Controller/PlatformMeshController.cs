using PaintIn3D;
using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlatformMeshController : MonoBehaviour
    {
        [SerializeField]
        private P3dPaintableTexture p3dPaintableTexture;

        private PlatformMeshData _platformMeshData;

        public void SetData(PlatformMeshData platformMeshData)
        {
            _platformMeshData = platformMeshData;
        }

        internal void ResetColor()
        {
            p3dPaintableTexture.Clear();
        }
    }
}