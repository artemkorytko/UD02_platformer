using System.Collections;
using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiGamePanel : MonoBehaviour
{
    [SerializeField] private UICoinText _coinsText;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SaveController save;

    private int Coin;
    
    private void OnEnable()
    {
//        _coinsText.UpdateText(_gameManager.Coins);
        _gameManager.OnCoinCountChanged += _coinsText.UpdateText;
    }

    private void OnDisable()
    {
        _gameManager.OnCoinCountChanged -= _coinsText.UpdateText;
        
    }
}
