﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKeyTransition : MonoBehaviour
{
    public GameObject AnyKeyIndicator;
    public float SecondsToIndicate;

    bool active;
    IEnumerator ShowIndicator() {
        yield return new WaitForSeconds(SecondsToIndicate);
        active = true;
        if (AnyKeyIndicator != null)
            AnyKeyIndicator.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowIndicator());
    }

    // Update is called once per frame
    void Update()
    {
        if (active && UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Jump")) {
            GetComponent<SceneLoader>().Load();
            
        }
    }
}