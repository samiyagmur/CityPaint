using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Level.Controller
{
    public class LevelSuccessfulPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private Button nextButton;

        private void Start()
        {
            InitButton();
        }

        private void InitButton()
        {
            nextButton.onClick.AddListener(delegate { OnPressNextLevelButton(); });
        }

        private void OnPressNextLevelButton()
        {
            manager.OnNextLevel();
        }
    }
}