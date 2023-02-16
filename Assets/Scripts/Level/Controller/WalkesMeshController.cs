using Scripts.Level.Data.ValueObject;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.Level.Controller
{
    public class WalkesMeshController : MonoBehaviour
    {
        [SerializeField]
        private new Renderer renderer;

        private WalkersMeshData _WalkersMeshData;

        private int _selectColorIndex;

        private Color _WalkersColor;

        internal void SetData(WalkersMeshData WalkersMeshData)
        {
            _WalkersMeshData = WalkersMeshData;
        }

        internal void InitMesh()
        {
            ChangeCollor();
        }
        internal void EnableMesh()
        {
            gameObject.SetActive(true);
        }

        internal void DisableMesh()
        {
            gameObject.SetActive(false);
        }
        
        private void ChangeCollor()
        {
            _selectColorIndex = Random.Range(0, _WalkersMeshData.color.Count);

            _WalkersColor = _WalkersMeshData.color[_selectColorIndex];

            renderer.material.color = _WalkersColor;
        }

        public Color GetWalkersColour()
        {
            return _WalkersColor;
        }
    }
}