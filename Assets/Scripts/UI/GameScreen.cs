using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Text goldCounterText;
        [SerializeField] private Text bronzeCounterText;
        [SerializeField] private Text silverCounterText;
        [SerializeField] private Joystick playerWalkJoystick;
        [SerializeField] private Button playerJumpButton;
        
        
        
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

        public Joystick PlayerWalkJoystick => playerWalkJoystick;

        public Button PlayerJumpButton => playerJumpButton;
    }
}
