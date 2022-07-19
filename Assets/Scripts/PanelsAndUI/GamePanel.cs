using Managers;
using UnityEngine;

namespace PanelsAndUI
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private UICoinText coinCount;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnEnable()
        {
            _gameManager.OnCoinCountChanged += coinCount.UpdateText;
        }
    }
}
