using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") != 0)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * 45, 0);
        }
    }
}
