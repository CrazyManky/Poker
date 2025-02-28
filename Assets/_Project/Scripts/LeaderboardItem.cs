using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LeaderboardItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private Image _medal;
        [SerializeField] private TextMeshProUGUI _coinScore;
        [SerializeField] private TextMeshProUGUI _score;

        public void SetData(string userName, int coinScore, int score, Sprite medal)
        {
            if (medal == null)
                _medal.gameObject.SetActive(false);
            
            _userName.text = userName;
            _coinScore.text = coinScore.ToString();
            _score.text = score.ToString();
            _medal.sprite = medal;
        }
    }
}