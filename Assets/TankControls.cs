using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TankControls : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject cube;
    public ghostScare camera;
    public void AddGhost(GameObject obj)
    {
        camera.relevantGhosts.Add(obj);
    }

    public void RemoveGhost(GameObject obj)
    {
        camera.relevantGhosts.Remove(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float z = CrossPlatformInputManager.GetAxis("Vertical");
        bool run = CrossPlatformInputManager.GetButton("Fire1");

        anim.SetFloat("Speed", z);
        anim.SetFloat("Direction", x);
        anim.SetBool("Run", run);
        if(z>0.5f && Mathf.Abs(x) > 0.2f)
        {
            transform.Rotate(new Vector3(0, x/(run ? 1: 3), 0));
        }

        if(Physics.Raycast(transform.position + transform.up*0.5f, Vector3.down, out RaycastHit hit, 10))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

    }
}
