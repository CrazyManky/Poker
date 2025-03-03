using System;
using UnityEngine;

namespace _Project.Scripts.DayliBonus
{
    public class HourlyRewardTimer
    {
        private const float HOURS_BETWEEN_REWARDS = 1f; // 1 час между наградами
        private const string LAST_REWARD_KEY = "LastHourlyRewardTime"; // Ключ для хранения времени

        private DateTime _lastRewardTime; // Время последнего получения награды

        public void Init()
        {
            LoadData();
        }

        private void LoadData()
        {
            // Загружаем время последнего получения из PlayerPrefs
            string lastRewardStr = PlayerPrefs.GetString(LAST_REWARD_KEY, DateTime.MinValue.ToString());
            _lastRewardTime = DateTime.Parse(lastRewardStr);
        }

        private void SaveData()
        {
            // Сохраняем текущее время как время получения награды
            PlayerPrefs.SetString(LAST_REWARD_KEY, DateTime.Now.ToString());
            PlayerPrefs.Save();
        }

        // Проверка готовности награды (вызывается вручную)
        public bool CheckRewardAvailability()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan timeSinceLastReward = currentTime - _lastRewardTime;
            double hoursPassed = timeSinceLastReward.TotalHours;

            return hoursPassed >= HOURS_BETWEEN_REWARDS;
        }

        // Метод для получения награды
        public bool TryClaimReward()
        {
            if (CheckRewardAvailability())
            {
                ClaimReward();
                return true;
            }

            float remainingHours = GetRemainingHours();
            Debug.Log($"Награда еще не готова! Осталось: {remainingHours:F2} часов");
            return false;
        }

        private void ClaimReward()
        {
            _lastRewardTime = DateTime.Now;
            SaveData();

            // Здесь добавьте логику выдачи награды
            Debug.Log("Игрок получил часовую награду!");
            // Например: PlayerInventory.AddCoins(50);
        }

        // Получить оставшееся время в часах
        public float GetRemainingHours()
        {
            TimeSpan timeRemaining = _lastRewardTime.AddHours(HOURS_BETWEEN_REWARDS) - DateTime.Now;
            return Mathf.Max(0, (float)timeRemaining.TotalHours);
        }

        // Для отладки: сброс таймера
        public void ResetTimer()
        {
            PlayerPrefs.DeleteKey(LAST_REWARD_KEY);
            LoadData();
            Debug.Log("Таймер сброшен");
        }
    }
}