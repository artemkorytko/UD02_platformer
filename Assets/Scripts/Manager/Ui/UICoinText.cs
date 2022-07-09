using TMPro;
using UnityEngine;


namespace Manager
{
    public class UICoinText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text = null;

        public void UpdateText(int count)
        {
            _text.text = count.ToString();
        }
    }
}