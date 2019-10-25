using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string CurrentSceneName;
    public string NextSceneName;
    public Color transitionColor;
    public void Load()
    {
        SavedScenes.StartTransition(CurrentSceneName, NextSceneName, transitionColor);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
