using _Project.Screpts.Services;
using _Project.Scripts.AudioHandler;
using Services;
using UnityEngine;

namespace _Project.Scripts.Screens
{
    public class DialogLauncher : MonoBehaviour, IService
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;
        [SerializeField] private AudioManager _audioManager;


        private BaseScreen _activeScreen;


        private void Awake()
        {
            ServiceLocator.Init();
            ServiceLocator.Instance.AddService(this);
            ServiceLocator.Instance.AddService(_audioManager);
        }

        private void Start() => ShowMenuScreen();

        public void ShowMenuScreen()
        {
            // _audioManager.PlayMenu();
            ShowScreen(_menuScreen);
        }

        public void ShowSettingsScreen() => ShowScreen(_settingsScreen);
        public void ShowLeaderScreen() => ShowScreen(_leaderboardScreen);
        // public void ShowLevelScreen() => ShowScreen(_levelScreen);

        // public void ShowGameScreen()
        // {
        //     _audioManager.PlayButtonClick();
        //     _audioManager.PlayGame();
        //     ShowScreen(_gameScreen);
        // }

        private void ShowScreen(BaseScreen screen)
        {
            _activeScreen?.Сlose();
            var instanceScreen = Instantiate(screen, transform);
            instanceScreen.Init();
            _activeScreen = instanceScreen;
        }
    }
}