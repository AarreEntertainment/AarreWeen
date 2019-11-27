using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public string buttonName;
    public UnityEngine.Events.UnityEvent ev;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            ev.Invoke();
        }
        
    }
}
