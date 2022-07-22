using UnityEngine;

namespace Lesson
{
    public class UIController: MonoBehaviour
    {
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject lostPanel;

        private GameObject currentPanel;

        private void EnableCurrentPanel()
        {
            if(currentPanel == null) return;

            currentPanel.SetActive(true);
        }
        
        private void DisableCurrentPanel()
        {
            if(currentPanel == null) return;

            currentPanel.SetActive(false);
        }

        public void ShowStartPanel()
        {
            DisableCurrentPanel();
            currentPanel = startPanel;
        }
        
        public void ShowGamePanel()
        {
            DisableCurrentPanel();
            currentPanel = gamePanel;
        }
        
        public void ShowWinPanel()
        {
            DisableCurrentPanel();
            currentPanel = winPanel;
        }
        
        public void ShowLostPanel()
        {
            DisableCurrentPanel();
            currentPanel = lostPanel;
        }
    }
}