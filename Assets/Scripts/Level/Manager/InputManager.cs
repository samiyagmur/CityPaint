using Scripts.Exteions;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {


        [SerializeField]
        private new Camera camera;

        [SerializeField]
        private RectTransform rectTransform;

        private bool _isFirstTouchTaken;
        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void Update()
        {
            if (_isFirstTouchTaken)
            {
                Vector3 mouseHitPoint = camera.GetClickPos(50);

                if (mouseHitPoint == null) return;

                CoreGameSignals.Instance.onDrag?.Invoke(mouseHitPoint);

                InputSignals.Instance.onDragMouse?.Invoke(Input.mousePosition);
            }
        }

        private void OnLevelInitilize() => StartToInput();

        private void OnReset() => StopToInput();

        private void StartToInput() => _isFirstTouchTaken = true;

        private void StopToInput() => _isFirstTouchTaken = false;
    }
}