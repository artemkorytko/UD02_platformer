using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UiController _uiController;
    private LevelManager _levelManager;
    private SaveController _saveConroller;
    private CameraController _cameraControlller;

    private SaveController.GameData _gameData;

    public event Action<int> OnCoinCountChanged;

    private void Awake()
    {
        _gameData = _saveConroller.LoadData();
        _uiController.ShowStartPanel();
    }

    private void OnDestroy()
    {
        _saveConroller.SaveData(_gameData);
    }

    public void StartGame()
    {
        _levelManager.InitialiseLevel(_gameData.Level);
        _uiController.ShowGamePanel();
        OnGameStarted();
    }

    private void OnGameStarted()
    {
        //loock at Player
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
        _uiController.ShowFallPanel();
        OnGameFinished();
    }
}