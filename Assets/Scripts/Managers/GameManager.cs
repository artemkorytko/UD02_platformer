using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private SaveController saveController;
    [SerializeField] private CameraController cameraController;

    private GameData _gameData;

    public event Action<int> OnCoinCountChanged;
    
    private void Awake()
    {
        _gameData = saveController.LoadData();
        uiController.ShowStartPanel();
    }

    private void OnDestroy()
    { 
        saveController.SaveData(_gameData);
    }

    public void StartGame()
    {
        levelManager.InstantiateLevel(_gameData.Level);
        uiController.ShowGamePanel();
        OnGameStarted();
    }

    private void OnGameStarted()
    {
        cameraController.Initialize(levelManager.Player.transform);
        levelManager.Player.OnWin += WinGame;
        levelManager.Player.OnDead += FailGame;
        levelManager.Player.OnCoinCollected += OnCoinCollected;
    }

    private void OnGameEnded()
    {
        levelManager.Player.OnWin -= WinGame;
        levelManager.Player.OnDead -= FailGame;
        levelManager.Player.OnCoinCollected -= OnCoinCollected;        
    }

    private void WinGame()
    {
        _gameData.Level++;
        uiController.ShowWinPanel();
        OnGameEnded();
    }

    private void FailGame()
    {
        uiController.ShowLostPanel();
        OnGameEnded();
        levelManager.DestroyCurrentLevel();
    }

    private void OnCoinCollected()
    {
        _gameData.Coins++;
        OnCoinCountChanged?.Invoke(_gameData.Coins);
    }
}
