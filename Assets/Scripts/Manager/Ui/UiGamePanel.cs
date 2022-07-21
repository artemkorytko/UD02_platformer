using UnityEngine;

namespace Manager.Ui
{
    public class UiGamePanel : MonoBehaviour
    {
        [SerializeField] private UICoinText _coinsText;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private SaveController save;

        private int Coin;
    
        private void OnEnable()
        {
        _coinsText.UpdateText(_gameManager.Coins);
            _gameManager.OnCoinCountChanged += _coinsText.UpdateText;
        }

        private void OnDisable()
        {
            _gameManager.OnCoinCountChanged -= _coinsText.UpdateText;
        
        }
    }
}
