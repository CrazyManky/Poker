using System.Collections.Generic;
using _Project.Scripts.AudioHandler;
using _Project.Scripts.SO;
using Services;
using TMPro;
using UnityEngine;
using Random = System.Random;


namespace _Project.Scripts.Screens
{
    public class ResolwScreen : MonoBehaviour
    {
        [SerializeField] private PlayerValue _playerValue;
        [SerializeField] private List<CardsSelected> _cardsSelected;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _coinValue;
        [SerializeField] private TextMeshProUGUI _factor;
        [SerializeField] private TextMeshProUGUI _ballsValue;

        private DialogLauncher _dialogLauncher;
        private AudioManager _audioManager;
        private Random _random = new();

        public void Init(List<CardsSelected> cards, PokerHandEvaluator.HandRank rank)
        {
            _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
            var factor = _random.Next(0, 5);
            var coinsValue = _random.Next(0, 101);
            var playerBalls = _random.Next(0, 100);
            _playerValue.AddValue(playerBalls);
            _factor.text = $"x{factor}";
            _coinValue.text = $"+ {coinsValue}";
            _ballsValue.text = $"{playerBalls}";
            _text.text = $"{rank}";
            for (int i = 0; i < cards.Count; i++)
            {
                _cardsSelected[i].SetData(cards[i].SelectedCard);
            }
        }

        public void ShowMenu()
        {
            _audioManager.PlayButtonClick();
            _dialogLauncher.ShowMenuScreen();
        }

        public void ShowGame()
        {
            _audioManager.PlayButtonClick();
            _dialogLauncher.ShowGameScreen();
        }
    }
}