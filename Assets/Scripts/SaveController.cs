using System;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private const string SAVE_KEY = "GameData";

    public void SaveData(GameData data)
    {
        string json = JsonUtility.ToJson(data);
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
}

[Serializable]
public class GameData
{
    public int Coins = 0;
    public int Level = 0;
}