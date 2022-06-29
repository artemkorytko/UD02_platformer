using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private GameObject _currentPanel;

    private void EnableCurrentPanel()
    {
        if (_currentPanel == null) return;

        _currentPanel.SetActive(true);
    }

    private void DisableCurrentPanel()
    {
        if (_currentPanel == null) return;

        _currentPanel.SetActive(false);
    }

    public void ShowsStartPanel()
    {
        DisableCurrentPanel();
        _currentPanel = startPanel;
        EnableCurrentPanel();
    }

    public void ShowsGamePanel()
    {
        DisableCurrentPanel();
        _currentPanel = gamePanel;
        EnableCurrentPanel();
    }

    public void ShowsWinPanel()
    {
        DisableCurrentPanel();
        _currentPanel = winPanel;
        EnableCurrentPanel();
    }

    public void ShowsLosePanel()
    {
        DisableCurrentPanel();
        _currentPanel = losePanel;
        EnableCurrentPanel();
    }
}
