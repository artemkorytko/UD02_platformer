using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _failScreen;

    private GameObject _currentScreen;

    private void Awake()
    {
        _currentScreen = _startScreen;
    }

    public void ShowStartScreen()
    {
        _currentScreen.SetActive(false);
        _startScreen.SetActive(true);
        _currentScreen = _startScreen;
    }
    public void ShowGameScreen()
    {
        _currentScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _currentScreen = _gameScreen;

    }
    public void ShowFailScreen()
    {
        _currentScreen.SetActive(false);
        _failScreen.SetActive(true);
        _currentScreen = _failScreen;
    }
    public void ShowWinScreen()
    {
        _currentScreen.SetActive(false);
        _winScreen.SetActive(true);
        _currentScreen = _winScreen;
    }
}
