using _Project.Scripts;
using _Project.Scripts.SO;
using UnityEngine;

public class BonusRound : BaseDailyBonus
{
    [SerializeField] private PlayRounds _playRounds;
    [SerializeField] private PlayerValue _playerValue;

    private void Start()
    {
        Slider.value = _playRounds.PlayRoundCount;
    }

    public override void AddReward()
    {
        if (_playRounds.PlayRoundCount >= 10)
        {
            _playerValue.AddValue(100);
            _playRounds.ResetPlayCount();
            Slider.value = 0f;
        }
    }
}