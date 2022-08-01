using System;
using System.Globalization;
using UnityEngine;
using TMPro;


namespace Lesson
{
    public class UIGameScene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText = null;
        [SerializeField] private TextMeshProUGUI healthText = null;
        [SerializeField] private SaveController saveController;
        private GameData gameData;
        private Health health;

        private void Start()
        {
            health = FindObjectOfType<Health>();
            gameData = saveController.LoadData();
            GameManager.Instance.OnCoinCountChanged += OnMoneyValueChanged;
            health.HealthСhanged += OnHealthValueChanged;
            OnMoneyValueChanged(gameData.Coins);
            OnHealthValueChanged(health.HealthValue);
        }

        private void OnMoneyValueChanged(int value)
        {
            moneyText.text = value.ToString();
        }

        private void OnHealthValueChanged(int value)
        {
            healthText.text = value.ToString();
        }
    }
}