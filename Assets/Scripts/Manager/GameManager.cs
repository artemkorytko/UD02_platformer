using System;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UiController _uiController;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private SaveController _saveController;
        [SerializeField] private CameraController _cameraController;
        
        private GameData _gameData;
        public int LevelIdex => _gameData.Level;
        public int Coins => _gameData.Coins;
        public event Action<int> OnCoinCountChanged;

        private void Awake()
        {
            _gameData = _saveController.LoadData();
            _uiController.ShowStartPanel();
        }

        private void OnDestroy()
        {
            _saveController.SaveData(_gameData);
        }

        public void StartGame()
        {
            _levelManager.InstantiateLevel(_gameData.Level);
            _uiController.ShowGamePanel();
            OnGameStarted();
        }

        private void OnGameStarted()
        {
            if (_levelManager.Player != null)
            {
                _cameraController.Initialize(_levelManager.Player.transform);
                _levelManager.Player.OnWin += WinGame;
                _levelManager.Player.OnDead += FailGame;
                _levelManager.Player.OnCoinCollected += OnCoinCollected;
            }
        }

        private void OnGameEnded()
        {
            _levelManager.Player.OnWin -= WinGame;
            _levelManager.Player.OnDead -= FailGame;
            _levelManager.Player.OnCoinCollected -= OnCoinCollected;
        }

        private void WinGame()
        {
            _gameData.Level++;
            _uiController.ShowWinPanel();
            OnGameEnded();
        }

        private void FailGame()
        {
            _uiController.ShowLostPanel();
            OnGameEnded();
        }

        private void OnCoinCollected()
        {
            _gameData.Coins++;
            OnCoinCountChanged?.Invoke(_gameData.Coins);
        }
    }
}