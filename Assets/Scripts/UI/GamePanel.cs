using UnityEngine;

public class GamePanel : MonoBehaviour
{
    private CoinsCounter _coinsCounter;
    private GameManager _gameManager;
    
    private void OnEnable()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _coinsCounter = GetComponentInChildren<CoinsCounter>();
        _gameManager.OnCoinCountChanged += _coinsCounter.ShowCoinsCount;
    }

    private void OnDisable()
    {
        _gameManager.OnCoinCountChanged -= _coinsCounter.ShowCoinsCount;
    }
}
