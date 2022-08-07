using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private GameObject failScreen;
        private GameObject _currentScreen;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnCoinCountChanged += ChangeMoneyCount;
        }
        
        
        private void EnableCurrentScreen()
        {
            if (_currentScreen == null) return;
            else
            {
                _currentScreen.SetActive(true);
            }
        }
        
        
        private void DisableCurrentScreen()
        {
            if (_currentScreen == null) return;
            _currentScreen.SetActive(false);
        }

        
        public void ShowStartScreen()
        {
            DisableCurrentScreen();
            _currentScreen = mainMenuScreen;
            EnableCurrentScreen();
        }        

        public void ShowGameScreen()
        {
            DisableCurrentScreen();
            _currentScreen = gameScreen;
            EnableCurrentScreen();
        }
        
        
        public void ShowWinScreen()
        {
            DisableCurrentScreen();
            _currentScreen = winScreen;
            EnableCurrentScreen();
        }


        public void ShowFailScreen()
        {
            DisableCurrentScreen();
            _currentScreen = failScreen;
            EnableCurrentScreen();
        }


        private void ChangeMoneyCount(int money)
        {
            Text counter = gameScreen.GetComponentInChildren<Text>();
            counter.text = money.ToString();
        }
    }
}