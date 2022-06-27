using UnityEngine;

namespace Platformer
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject lostPanel;

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

        public void ShowLostPanel()
        {
            DisableCurrentPanel();
            _currentPanel = lostPanel;
            EnableCurrentPanel();
        }
    }
}