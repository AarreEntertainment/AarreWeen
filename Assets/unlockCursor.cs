﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}