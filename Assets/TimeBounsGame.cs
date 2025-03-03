using _Project.Scripts;
using _Project.Scripts.SO;
using UnityEngine;

public class TimeBounsGame : BaseDailyBonus
{
    [SerializeField] private TimeBonus _timeBonus;
    [SerializeField] private PlayerValue _playerValue;

    public void Start()
    {
        _timeBonus.HourlyRewardTimer.Init();
        Slider.maxValue = 1f;
        Slider.value = _timeBonus.HourlyRewardTimer.GetRemainingHours();
    }

    public override void AddReward()
    {
        if (_timeBonus.HourlyRewardTimer.CheckRewardAvailability())
        {
            _playerValue.AddValue(100);
            _timeBonus.HourlyRewardTimer.ResetTimer();
            Slider.value = 0;
        }
    }
}