using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;

    private GameObject _currentPanel;

    private void DisableCurrentPanel()
    {
        if (_currentPanel == null) return;
        _currentPanel.SetActive(false);
    }

    private void EnableCurrentPanel()
    {
        if (_currentPanel == null) return;
        _currentPanel.SetActive(true);
    }

    public void ShowStartPanel()
    {
        DisableCurrentPanel();
        _currentPanel = startPanel;
        EnableCurrentPanel();
    }

    public void ShowGamePanel()
    {
        DisableCurrentPanel();
        _currentPanel = gamePanel;
        EnableCurrentPanel();
    }

    public void ShowWinPanel()
    {
        DisableCurrentPanel();
        _currentPanel = winPanel;
        EnableCurrentPanel();
    }

    public void ShowFallPanel()
    {
        DisableCurrentPanel();
        _currentPanel = lostPanel;
        EnableCurrentPanel();
    }
}