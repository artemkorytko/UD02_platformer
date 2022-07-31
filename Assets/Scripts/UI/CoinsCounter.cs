using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    public void ShowCoinsCount(int coinsCount)
    {
        coinsText.text = coinsCount.ToString();
    }
}
