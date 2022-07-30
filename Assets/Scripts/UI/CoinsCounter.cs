using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    private void Awake()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.OnCoinCountChanged += ShowCoinsCount;
    }

    private void ShowCoinsCount(int coinsCount)
    {
        coinsText.text = coinsCount.ToString();
    }
}
