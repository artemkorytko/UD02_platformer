using System;
using Managers;
using TMPro;
using UnityEngine;

namespace PanelsAndUI
{
    public class UICoinText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        private SaveController _saveController;
        private SaveController.GameData _gameData;
        
        private void Awake()
        {
            _saveController = FindObjectOfType<SaveController>();
            _gameData = _saveController.LoadData();
        }

        public void OnEnable()
        {
            int coins = _gameData.Coins;
            coinText.text = coins.ToString();
        }
    }
}