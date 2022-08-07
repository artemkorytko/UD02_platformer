using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private Text GoldCounterText;
    [SerializeField] private Text BronzeCounterText;
    [SerializeField] private Text SilverCounterText;
    [SerializeField] private List<Button> startLevelButtons;


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
