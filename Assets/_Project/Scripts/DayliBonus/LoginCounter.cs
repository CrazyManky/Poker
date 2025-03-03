using System;
using UnityEngine;

namespace _Project.Scripts.DayliBonus
{
    public class LoginCounter
    {
        private const string LAST_LOGIN_KEY = "LastLoginDate"; 
        private const string CONSECUTIVE_DAYS_KEY = "ConsecutiveDays"; 

        private DateTime _lastLoginDate; 
        private int _consecutiveDays; 

        public void Init()
        {
            LoadData();
            UpdateConsecutiveDays();
        }

        private void LoadData()
        {
            string lastLoginStr = PlayerPrefs.GetString(LAST_LOGIN_KEY, DateTime.MinValue.ToString());
            _lastLoginDate = DateTime.Parse(lastLoginStr);

            _consecutiveDays = PlayerPrefs.GetInt(CONSECUTIVE_DAYS_KEY, 0);
        }

        private void SaveData()
        {
            PlayerPrefs.SetString(LAST_LOGIN_KEY, DateTime.Now.ToString());
            PlayerPrefs.SetInt(CONSECUTIVE_DAYS_KEY, _consecutiveDays);
            PlayerPrefs.Save();
        }

        private void UpdateConsecutiveDays()
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan timeDifference = currentDate - _lastLoginDate;

            double daysDifference = timeDifference.TotalDays;

            if (daysDifference >= 2)
            {
                _consecutiveDays = 1;
                Debug.Log("Цепочка прервана. Новый старт: 1 день");
            }
            else if (daysDifference >= 1 && daysDifference < 2)
            {
                _consecutiveDays++;
                Debug.Log($"Цепочка продолжается: {_consecutiveDays} дней подряд");
            }
            else
            {
                Debug.Log($"Сегодня уже заходили. Текущая цепочка: {_consecutiveDays} дней");
            }

            SaveData();

            Debug.Log($"Последний вход: {_lastLoginDate}, Текущий прогресс: {_consecutiveDays} дней подряд");
        }

        public void ResetProgress()
        {
            PlayerPrefs.DeleteKey(LAST_LOGIN_KEY);
            PlayerPrefs.DeleteKey(CONSECUTIVE_DAYS_KEY);
            LoadData();
            Debug.Log("Прогресс сброшен");
        }

        public int GetConsecutiveDays()
        {
            return _consecutiveDays;
        }
    }
}