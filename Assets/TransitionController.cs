using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    bool init;
    bool exit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = SavedScenes.TransitionColor;
        init = true;
        exit = false;
    }
    AsyncOperation loadop;
    // Update is called once per frame
    void Update()
    {
        if (loadop != null)
        {
            if (loadop.isDone)
            {
                exit = true;
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(SavedScenes.NextLevel));
                
            }
        }
        if (init && GetComponent<Image>().color.a < 1)
        {
            Color col = GetComponent<Image>().color;
            col.a += Time.deltaTime;
            GetComponent<Image>().color = col;

            
        }
        else if (init && GetComponent<Image>().color.a >= 1)
        {

                SavedScenes.Unload(SavedScenes.CurrentLevel);
                init = false;
                loadop = SceneManager.LoadSceneAsync(SavedScenes.NextLevel, LoadSceneMode.Additive);
                loadop.allowSceneActivation = true;
        }
        else if (exit)
        {
                
            Color col = GetComponent<Image>().color;
            col.a -= Time.deltaTime;
            GetComponent<Image>().color = col;
            if (GetComponent<Image>().color.a <= 0)
            {
                SavedScenes.Unload("Transition");
            }
        }
    }
}
