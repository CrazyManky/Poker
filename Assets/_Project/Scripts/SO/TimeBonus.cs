using _Project.Scripts.DayliBonus;
using UnityEngine;

namespace _Project.Scripts.SO
{
    [CreateAssetMenu(fileName = "DayBonus", menuName = "DayBonus")]
    public class TimeBonus : ScriptableObject
    {
        [SerializeField] private PlayerValue _playerValue;
        [SerializeField] private int _loginDays;

        private LoginCounter _loginCounter = new LoginCounter();
        private HourlyRewardTimer _hourlyRewardTimer = new HourlyRewardTimer();

        public LoginCounter LoginCounter => _loginCounter;
        public HourlyRewardTimer HourlyRewardTimer => _hourlyRewardTimer;

        public void Awake()
        {
            _loginCounter.Init();
            _hourlyRewardTimer.Init();
            _loginDays = _loginCounter.GetConsecutiveDays();
        }

        public void TakeRewardDayse()
        {
            if (_loginDays == 7)
                _playerValue.AddValue(100);
        }

        public void SurpriceReward()
        {
        }
    }
}