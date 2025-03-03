using System.Collections.Generic;
using _Project.Scripts.SO;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Screens
{
    public class GamePlayScreen : BaseScreen
    {
        [SerializeField] private PlayerValue _playerValue;
        [SerializeField] private CardsData _cardsData;
        [SerializeField] private List<CardsSelected> _cardsSelected;
        [SerializeField] private HelperScreen _helperScreen;
        [SerializeField] private ResolwScreen _resolwScreen;
        [SerializeField] private TextMeshProUGUI _playerValueText;
        [SerializeField] private PlayRounds _playRounds;

        public override void Init()
        {
            base.Init();
            _playerValueText.text = $"{_playerValue.Value}";
            foreach (var cardSelected in _cardsSelected)
                cardSelected.SetData(_cardsData.GetRandomCard());
        }


        public void ReplaceCards()
        {
            foreach (var cardSelected in _cardsSelected)
            {
                if (cardSelected.ISelected)
                {
                    cardSelected.SetData(_cardsData.GetRandomCard());
                    cardSelected.SelectedSwitch();
                }
            }
        }

        public void CheckCombination()
        {
            AudioManager.PlayButtonClick();
            var result = PokerHandEvaluator.EvaluateHand(_cardsSelected);
            var screen = Instantiate(_resolwScreen, transform);
            screen.Init(_cardsSelected, result);
            _playRounds.AddPlayRound();
        }

        public void BackToMenu()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }

        public void ShowHelperScreen()
        {
            AudioManager.PlayButtonClick();
            Instantiate(_helperScreen, transform);
        }
    }
}