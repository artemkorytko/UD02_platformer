using System;
using Platformer;
using UnityEngine;

namespace Platformer
{
    
    public class GameManager : MonoBehaviour
    { 
        private UIManager _uiManager;
        private LevelManager _level;
        //private SaveSystem _saveSystem;
        private CameraController _cameraController;
        //private GameData _gameData;
        public event Action<int> OnCoinCountChanged;
    

        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
            //_saveSystem.LoadData();
            //_uiManager.ShowMainMenuScreen();
        }
        

        private void OnGameStarted()
        {
            //_cameraController.Initialize(_level, _level.Player.transform);
            _level.Player.OnCoinCollected += OnCoinCollected;
            _level.Player.OnWin += OnGameWon;
            _level.Player.OnDead += OnGameFailed;
        }

        private void OnCoinCollected(int obj)
        {
            
        }


        private void OnCoinCollected()
        {
            
        }


        private void OnGameWon()
        {
            
        }
        
        private void OnGameFailed()
        {
            

        }
        
        
        private void OnGameEnded()
        {
            _level.Player.OnCoinCollected -= OnCoinCollected;
            _level.Player.OnWin -= OnGameWon;
            _level.Player.OnDead -= OnGameFailed;

        }
    }

}