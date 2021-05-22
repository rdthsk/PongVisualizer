using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);
    public static T Instance => LazyInstance.Value;

    private static T CreateSingleton()
    {
        var ownerObject = new GameObject($"{typeof(T).Name} (singleton)");
        var instance = ownerObject.AddComponent<T>();
        DontDestroyOnLoad(ownerObject);
        return instance;
    }
}

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public int score;
    [HideInInspector] public int currCombo;

    public void ClearComboAndAddScore()
    {
        score += currCombo;
        currCombo = 0;
    }

    public void AddToCombo()
    {
        currCombo++;
    }
}