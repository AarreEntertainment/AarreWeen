using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SavedScenes
{
    public static string CurrentLevel;
    public static string NextLevel;
    public static Color TransitionColor;

    public static void StartTransition(string Current, string Next, Color color)
    {
        CurrentLevel = Current;
        NextLevel = Next;
        SceneManager.LoadSceneAsync("Transition", LoadSceneMode.Additive);
        
    }
    public static void Unload(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
    public static void Load(string scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
}
