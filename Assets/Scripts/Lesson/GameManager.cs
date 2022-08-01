using System;
using UnityEngine;

namespace Lesson
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private SaveController _saveController;
        [SerializeField] private CameraController _cameraMovement;

        private GameData gameData;
        public static GameManager Instance = null;

        public event Action<int> OnCoinCountChanged;

        private int _coin = 0;

        public int Coin
        {
            get
            {
                return _coin;
            }

            set
            {
                if (value >= 0)
                {
                    _coin = value;
                    OnCoinCountChanged?.Invoke(_coin);
                }
            }
        }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            gameData = _saveController.LoadData();
            _uiController.ShowStartPanel();
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