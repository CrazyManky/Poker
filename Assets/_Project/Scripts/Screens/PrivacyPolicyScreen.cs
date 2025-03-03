using _Project.Scripts.AudioHandler;
using Services;
using UnityEngine;

namespace _Project.Scripts.Screens
{
    public class PrivacyPolicyScreen : MonoBehaviour
    {
       private AudioManager _audioManager;

        private void Start()
        {
           _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void Close()
        {
           _audioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}