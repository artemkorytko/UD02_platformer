using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private UiController _uiController;
        private SaveController _saveController;
        private LevelManager _levelManager;
        private CameraController _cameraControlller;
        private SaveController.GameData _gameData;

        public event Action<int> OnCoinCountChanged;

        private void Awake()
        {
            _uiController = FindObjectOfType<UiController>();
            _saveController = FindObjectOfType<SaveController>();
            _levelManager = FindObjectOfType<LevelManager>();
            _cameraControlller = FindObjectOfType<CameraController>();
            _gameData = _saveController.LoadData();
            _uiController.ShowStartPanel();
        }

        private void OnDestroy()
        {
            _saveController.SaveData(_gameData);
        }

        public void StartGame()
        {
            _levelManager.InitialiseLevel(_gameData.Level);
            _uiController.ShowGamePanel();
            OnGameStarted();
        }

        private void OnGameStarted()
        {
            //look at Player
            _cameraControlller.Initialize(_levelManager.PlayerController.transform);
            _levelManager.PlayerController.OnWin += WinGame;
            _levelManager.PlayerController.OnDeath += LostGame;
            _levelManager.PlayerController.OnCoinCollected += OnCoinCollected;
        }

        private void OnGameFinished()
        {
            _levelManager.PlayerController.OnWin -= WinGame;
            _levelManager.PlayerController.OnDeath -= LostGame;
            _levelManager.PlayerController.OnCoinCollected -= OnCoinCollected;
        }

        private void OnCoinCollected()
        {
            _gameData.Coins++;
            OnCoinCountChanged?.Invoke(_gameData.Coins);
        }

        private void WinGame()
        {
            _gameData.Level++;
            _uiController.ShowWinPanel();
            OnGameStarted();
        }

        private void LostGame()
        {
            OnDestroy();
            _uiController.ShowFallPanel();
            OnGameFinished();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}