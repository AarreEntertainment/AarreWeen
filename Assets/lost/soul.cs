using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soul : MonoBehaviour
{
    public Material OffMaterial;
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TankControls>() != null)
        {
            other.GetComponent<TankControls>().AddGhost(ghost);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankControls>() != null)
        {
            other.GetComponent<TankControls>().RemoveGhost(ghost);
        }
    }
    GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        else
        {
            if(Vector3.Distance(player.transform.position, transform.position) < 2)
            {
                player.GetComponent<TankControls>().souls.Remove(this.transform);
                transform.parent.GetComponent<AudioSource>().Play();
                GetComponentInParent<Renderer>().materials = new Material[] { OffMaterial };
                Destroy(gameObject);
            }
        }
    }
}
