using Signals;
using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip weaponSound;

        [SerializeField]
        private AudioClip levelUpSound;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            AudioSignals.Instance.onPullTheWeaponTrigger += OnPullTheWeaponTrigger;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            AudioSignals.Instance.onPullTheWeaponTrigger -= OnPullTheWeaponTrigger;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnNextLevel()
        {
            audioSource.PlayOneShot(levelUpSound);
        }

        private void OnPullTheWeaponTrigger()
        {
            audioSource.PlayOneShot(weaponSound);
        }
    }
}