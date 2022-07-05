using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UICoinText : MonoBehaviour
    {
        [SerializeField] private Text _text = null;

        public void UpdateText(int count)
        {
            _text.text = count.ToString();
        }
    }
}