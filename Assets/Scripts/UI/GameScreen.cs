using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Text _goldCounterText;
    [SerializeField] private Text _bronzeCounterText;
    [SerializeField] private Text _silverCounterText;

    
    public Text GoldCounterText
    {
        get => _goldCounterText;
        set => _goldCounterText.text = value.ToString();
    }

    public Text BronzeCounterText
    {
        get => _bronzeCounterText;
        set => _bronzeCounterText.text = value.ToString();
    }

    public Text SilverCounterText
    {
        get => _silverCounterText;
        set => _silverCounterText.text = value.ToString();
    }
}
