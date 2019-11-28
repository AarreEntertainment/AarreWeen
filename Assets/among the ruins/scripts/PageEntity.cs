using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageEntity : MonoBehaviour
{
    public string Page;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChangePage>() != null)
        {
            other.GetComponent<ChangePage>().Change(Page);
            other.GetComponent<ChangePage>().StartTimer(this.gameObject);
            other.GetComponent<ChangePage>().timerRunning = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ChangePage>() != null)
        {
            other.GetComponent<ChangePage>().Close();

            other.GetComponent<ChangePage>().timerRunning = false;
            other.GetComponent<ChangePage>().timer = 0;
        }
    }
}
