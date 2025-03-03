using UnityEngine;

namespace _Project.Scripts.SO
{
    [CreateAssetMenu(fileName = "Config", menuName = "PlayRounds")]
    public class PlayRounds : ScriptableObject
    {
        [property: SerializeField] public int PlayRoundCount { get; private set; }

        public void AddPlayRound()
        {
            PlayRoundCount++;
        }

        public void ResetPlayCount()
        {
            PlayRoundCount = 0;
        }
    }
}