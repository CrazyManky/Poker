using System;
using _Project.Scripts.AudioHandler;
using Services;
using UnityEngine;

namespace _Project.Scripts.Screens
{
    public class HelperScreen : MonoBehaviour
    {
        private AudioManager _audioManager;
        private void Start()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void Back()
        {
            _audioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}
