using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuScreen : MonoBehaviour
    {
        [SerializeField] private Text goldCounterText;
        [SerializeField] private Text bronzeCounterText;
        [SerializeField] private Text silverCounterText;
        [SerializeField] public List<Button> startLevelButtons;

        public Text GoldCounterText
        {
            get => goldCounterText;
            set => goldCounterText.text = value.ToString();
        }

        public Text BronzeCounterText
        {
            get => bronzeCounterText;
            set => bronzeCounterText.text = value.ToString();
        }

        public Text SilverCounterText
        {
            get => silverCounterText;
            set => silverCounterText.text = value.ToString();
        }


        private void Awake()
        {
            for (int i = 0; i < startLevelButtons.Count; i++)
            {
                startLevelButtons[i].onClick.AddListener(ButtonUsed(startLevelButtons[i]));
            }
        }
        public UnityAction ButtonUsed(Button button)
        {
            button.GetComponent<Text>().text = ("Retry");
            return null;
        }
    

    }
}
