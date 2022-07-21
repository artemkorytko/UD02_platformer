using UnityEngine;
using UnityEngine.UI;
using static SaveController;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private LevelController _level;
    [SerializeField] private SaveController _saveController;
    [SerializeField] private CameraController _camera;
    [SerializeField] private Text _goldText;

    private GameData _gameData;

    private void Awake()
    {
        _uiManager.ShowStartScreen();
        _gameData = _saveController.LoadData();
    }

    public void StartGame()
    {
        _level.InstantiateLevel(_gameData.Level);
        _uiManager.ShowGameScreen();
        _goldText.text = _gameData.Golds.ToString();
        _level.Player.OnDied += Dead;
        _level.Player.OnFinish += Win;
        _level.Player.OnGold += AddGold;
        _camera.Initialize(_level.Player.transform);
    }

    private void Dead()
    {
        _uiManager.ShowFailScreen();
        _saveController.SaveData(_gameData);
    }

    private void Win()
    {
        _gameData.Level++;
        _uiManager.ShowWinScreen();
        _saveController.SaveData(_gameData);
    }

    private void AddGold()
    {
        _gameData.Golds++;
        _goldText.text = _gameData.Golds.ToString();
    }


}
