﻿using UnityEngine;

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

    private void ShowPanel(GameObject panel)
    {
        DisableCurrentPanel();
        _currentPanel = panel;
        EnableCurrentPanel();
    }

    public void ShowStartPanel()
    {
        ShowPanel(startPanel);
    }
    
    public void ShowGamePanel()
    {
        ShowPanel(gamePanel);
    }
    
    public void ShowWinPanel()
    {
        ShowPanel(winPanel);
    }
    
    public void ShowLostPanel()
    {
        ShowPanel(losePanel);
    }
}
