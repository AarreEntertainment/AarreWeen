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
            Debug.Log("player entered");
            other.GetComponent<ChangePage>().Change(Page);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ChangePage>() != null)
        {
            other.GetComponent<ChangePage>().Close();
        }
    }

}
