using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using Firebase.Analytics;
using System;

public class FireBaseManager : MonoBehaviour
{
    private GameManager _gameManager;

    public async UniTask Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        await CrashlyticsInitialize();
        await AnalyticsInitialize();

    }

    //private void Start()
    //{
    //    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
    //    {
    //        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
    //        var app = FirebaseApp.DefaultInstance;
    //    });
    //    Debug.Log($"Analytics Initialize completed");

    //    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
    //        var dependencyStatus = task.Result;
    //        if (dependencyStatus == DependencyStatus.Available)
    //        {
    //            FirebaseApp app = FirebaseApp.DefaultInstance;
    //        }
    //        else
    //        {
    //            Debug.LogError(String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
    //        }
    //    });
    //    Debug.Log($"Crashlytics Initialize completed");
    //}
    private async UniTask AnalyticsInitialize()
    {
        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            var app = FirebaseApp.DefaultInstance;
        });
        Debug.Log($"Analytics Initialize completed");
    }

    private async UniTask CrashlyticsInitialize()
    {
         await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
            }
            else
            {
                Debug.LogError(String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
        Debug.Log($"Crashlytics Initialize completed");
    }

    public void LevelUpEvent()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp);
    }

    public void LevelStart()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
    }

    public void Restart()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventBeginCheckout);
    }
}
