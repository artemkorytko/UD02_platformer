using System;
using UnityEngine;

namespace Lesson
{
    public class GameManager : MonoBehaviour
    {
        private UIController _uiController;
        private LevelManager _levelManager;
        private SaveController _saveController;
        private CameraController _cameraMovement;

        private GameData gameData;

        public event Action<int> OnCoinCountChanged;

        private void Awake()
        {
            gameData = _saveController.LoadData();
            _uiController.ShowStartPanel();
            StartGame();
        }

        private void OnDestroy()
        {
            _saveController.SaveData(gameData);
        }

        public void StartGame()
        {
            _levelManager.InstatiateLevel(gameData.Level);
            _uiController.ShowGamePanel();
            OnGameStarted();
        }

        private void OnGameStarted()
        {
            _cameraMovement.Initialize(_levelManager.Player.transform);
            _levelManager.Player.OnWin += WinGame;
            _levelManager.Player.OnDead += FailGame;
            _levelManager.Player.OnCoinCollected += OnCoinCollected;
        }
        
        private void OnGameEnded()
        {
            _levelManager.Player.OnWin -= WinGame;
            _levelManager.Player.OnDead -= FailGame;
            _levelManager.Player.OnCoinCollected -= OnCoinCollected;
        }

        private void WinGame()
        {
            gameData.Level++;
            _uiController.ShowWinPanel();
        }
        
        private void FailGame()
        {
            _uiController.ShowLostPanel();
            OnGameEnded();
        }
        
        private void OnCoinCollected()
        {
            gameData.Coins++;
            OnCoinCountChanged?.Invoke(gameData.Coins);
        }
    }
}