using _Project.Scripts;
using _Project.Scripts.SO;
using UnityEngine;
using UnityEngine.Serialization;

public class DayBonus : BaseDailyBonus
{
    [FormerlySerializedAs("_daylinBonus")] [SerializeField]
    private TimeBonus timeBonus;

    [SerializeField] private PlayerValue _playerValue;

    private void Start()
    {
        timeBonus.LoginCounter.Init();
        Slider.maxValue = 7;
        Slider.value = timeBonus.LoginCounter.GetConsecutiveDays();
    }

    public override void AddReward()
    {
        if (timeBonus.LoginCounter.GetConsecutiveDays() >= 7)
        {
            _playerValue.AddValue(100);
            timeBonus.LoginCounter.ResetProgress();
            Slider.value = 0f;
        }
    }
}