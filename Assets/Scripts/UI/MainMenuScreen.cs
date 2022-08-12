using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private Text _goldCounterText;
    [SerializeField] private Text _bronzeCounterText;
    [SerializeField] private Text _silverCounterText;
    [SerializeField] public List<Button> startLevelButtons;

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
