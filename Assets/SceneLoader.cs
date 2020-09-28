using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string CurrentSceneName;
    public string NextSceneName;
    public Color transitionColor;
    bool loaded = false;
    public void Load()
    {
        if (!loaded)
        {
            loaded = true;
            SavedScenes.StartTransition(CurrentSceneName, NextSceneName, transitionColor);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
