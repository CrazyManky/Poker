using _Project.Configs;
using _Project.Screpts.Screns;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Screens
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] private SoundConfig _audioManager;
        [SerializeField] private PrivacyPolicyScreen _privacyPolicyScreen;
        [SerializeField] private RectTransform _privacyPolicyContainer;
        [Header("Buttons")] [SerializeField] private Image _imageSound;
        [SerializeField] private Image _imageMusic;
        [SerializeField] private Sprite _valueActive;
        [SerializeField] private Sprite _valueDisabled;

        public override void Init()
        {
            base.Init();
            _imageSound.sprite = _audioManager.SoundActive ? _valueActive : _valueDisabled;
            _imageMusic.sprite = _audioManager.MusicActive ? _valueActive : _valueDisabled;
        }

        public void SwitchValueSound()
        {
          //  AudioManager.PlayButtonClick();
            _audioManager.SetSound(!_audioManager.SoundActive);
            _imageSound.sprite = _audioManager.SoundActive ? _valueActive : _valueDisabled;
        }

        public void SwitchValueMusic()
        {
           // AudioManager.PlayButtonClick();
            _audioManager.SetMusic(!_audioManager.MusicActive);
            _imageMusic.sprite = _audioManager.MusicActive ? _valueActive : _valueDisabled;
        }

        public void ShowPrivacyPolicy()
        {
           // AudioManager.PlayButtonClick();
            Instantiate(_privacyPolicyScreen, _privacyPolicyContainer);
        }

        public void BackToMenu()
        {
            //  AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }
    }
}