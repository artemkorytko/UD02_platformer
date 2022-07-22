using System;
using UnityEngine;

namespace Lesson
{
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

        public GameData GameData
        {
            get => JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(SAVE_KEY, JsonUtility.ToJson(new GameData())));
            set => PlayerPrefs.SetString(SAVE_KEY, JsonUtility.ToJson(value));
        }
        
        public int Level
        {
            get => PlayerPrefs.GetInt(SAVE_KEY, 0);
            set => PlayerPrefs.SetInt(SAVE_KEY, value);
        }
    }

    [Serializable]
    public class GameData
    {
        public int Coins = 0;
        public int Level = 0;
    }
}