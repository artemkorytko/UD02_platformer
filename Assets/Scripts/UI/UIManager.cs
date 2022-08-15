using Platformer;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] public MainMenuScreen mainMenuScreen;
        [SerializeField] public GameScreen gameScreen;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private GameObject failScreen;
        [SerializeField] private Button playerJumpButton;      // СДЕЛАТЬ ZENJECT, убогая зависимомть
        [SerializeField] private Joystick playerJoystick;
        private GameObject _currentScreen;
        private GameManager _gameManager;

        public Button PlayerJumpButton => playerJumpButton;

        public Joystick PlayerJoystick { get; private set; }


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

        
        public void ShowMainMenuScreen()
        {
            DisableCurrentScreen();
            _currentScreen = mainMenuScreen.GameObject();
            EnableCurrentScreen();
        }        

        public void ShowGameScreen()
        {
            DisableCurrentScreen();
            _currentScreen = gameScreen.GameObject();
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