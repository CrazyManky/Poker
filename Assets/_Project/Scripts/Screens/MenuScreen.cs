using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


namespace _Project.Scripts.Screens
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private List<BaseDailyBonus> _list;

        private Random _random = new();

        public override void Init()
        {
            base.Init();
            var daylingBonus = Instantiate(_list[_random.Next(0, _list.Count)], transform);
            daylingBonus.Show();
        }

        public void ShowSettingsScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }

        public void ShowLeaderScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowLeaderScreen();
        }

        public void ShowGameScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowGameScreen();
        }

        public void ShowRewardScreen()
        {
            Dialog.ShowRewardScreen();
        }
    }
}