using Managers;
using Scripts.Exteions;
using Scripts.Level.Data.ValueObject;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private TextMeshProUGUI money;

        [SerializeField]
        private TextMeshProUGUI bullet;

        [SerializeField]
        private TextMeshProUGUI income;

        [SerializeField]
        private TextMeshProUGUI walkers;

        [SerializeField]
        private TextMeshProUGUI fireRate;

        [SerializeField]
        private TextMeshProUGUI ammo;

        [SerializeField]
        private Button incomeButton;

        [SerializeField]
        private Button walkersButton;

        [SerializeField]
        private Button fireRateButton;

        [SerializeField]
        private Button ammoButton;

        [SerializeField]
        private Image bulletImage;

        [SerializeField]
        private Image levelImage;

        [SerializeField]
        private RectTransform canvas;

        [SerializeField]
        private RectTransform crossHair;

        private void Start()
        {
            InitButton();
        }

        private void InitButton()
        {
            incomeButton.onClick.AddListener(delegate { OnPressInCome(); });
            walkersButton.onClick.AddListener(delegate { OnPressWalkers(); });
            fireRateButton.onClick.AddListener(delegate { OnPressFireRate(); });
            ammoButton.onClick.AddListener(delegate { OnPressAmmo(); });
        }

        private void OnPressInCome()
        {
            manager.OnPressInComeButton();
        }

        private void OnPressWalkers()
        {
            manager.OnPressWalkersButton();
        }

        private void OnPressFireRate()
        {
            manager.OnPressFireRateButton();
        }

        private void OnPressAmmo()
        {
            manager.OnPressAmmoButton();
        }

        internal void InitMoneyScore(int value)
        {
            money.text = value.ToString();
        }

        internal void InitLevelPanel()
        {
            crossHair.gameObject.SetActive(true);
        }

        internal void ResetLevelPanel()
        {
            crossHair.gameObject.SetActive(false);
        }

        internal void FollowMousePos(Vector2 mousePos)
        {
            canvas.FollowUIElementToMousePosition(crossHair, mousePos);
        }

        internal void PrintBulletCount(int bulletCount)
        {
            if (bulletCount == 0)
            {
                bulletImage.fillAmount = 0;

                bullet.text = " ";
                ShowReloadClip();
            }
            else
            {
                bullet.text = bulletCount.ToString();
            }
        }

        private async void ShowReloadClip()
        {
            while (bulletImage.fillAmount < 1)
            {
                bulletImage.fillAmount += 0.005f;

                await Task.Delay(10);
            }
        }

        internal void SetShopEnhancements(ShopData shopData)
        {
            income.text = "$ " + shopData.InCome[shopData.InComeLevel].Price;
            walkers.text = "$ " + shopData.Walkers[shopData.WalkersLevel].Price;
            fireRate.text = "$ " + shopData.FireRate[shopData.FireRateLevel].Price;
            ammo.text = "$ " + shopData.Ammo[shopData.AmmoLevel].Price;
        }

        internal void UpdateLevelImage(int deadCount, int enoughDeadCountForLevelUp)
        {
            levelImage.fillAmount = (float)deadCount / enoughDeadCountForLevelUp;
        }
    }
}