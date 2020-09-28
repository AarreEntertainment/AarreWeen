using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class buttonListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public InputControlType control;
    public UnityEngine.Events.UnityEvent ev;
    // Update is called once per frame
    bool pressed = false;
    void Update()
    {
        
        if (InputManager.ActiveDevice.GetControl(control).WasPressed && !pressed)
        {
            ev.Invoke();
            
        }
        
    }
}
