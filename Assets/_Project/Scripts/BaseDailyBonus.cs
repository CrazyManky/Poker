using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public abstract class BaseDailyBonus : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;
        [SerializeField] protected RectTransform MyRectTransform;

        public void Show()
        {
            MyRectTransform.DOAnchorPosY(0, 1f);
        }

        public abstract void AddReward();
    }
}