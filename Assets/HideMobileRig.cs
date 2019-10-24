using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMobileRig : MonoBehaviour
{
    public Settings setting;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(setting.touchControls);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
