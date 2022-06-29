using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveController : MonoBehaviour
{
    private const string SAVE_KEY = "GameData";

    public void SaveData(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    public GameData LoadData()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            return JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(SAVE_KEY));
        }
        else
        {
            return new GameData();
        }
    }

    public GameData GameData 
    {
        get
        {
            return JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(SAVE_KEY, JsonUtility.ToJson(new GameData())));
        }
        set
        {
            PlayerPrefs.SetString(SAVE_KEY, JsonUtility.ToJson(value));
        }
    }
}

[Serializable]
public class GameData
{
    public int Coins;
    public int Levels;


}
