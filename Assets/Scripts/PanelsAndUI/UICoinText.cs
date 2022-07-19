using TMPro;
using UnityEngine;

namespace PanelsAndUI
{
    public class UICoinText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;

        public void UpdateText(int count)
        {
            coinText.text = count.ToString();
        }
    }
}