using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentFind : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MonsterController>() != null)
        {
            other.GetComponent<MonsterController>().NextScent();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
