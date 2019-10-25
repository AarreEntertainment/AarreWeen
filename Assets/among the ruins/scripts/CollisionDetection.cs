using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent ev;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
            ev.Invoke();
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
