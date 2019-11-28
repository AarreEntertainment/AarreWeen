using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lifetime());   
    }
    IEnumerator lifetime()
    {
        yield return new WaitForSeconds(Random.value * 10);
        GetComponent<Animator>().SetTrigger("die");
    }

    public void destruct()
    {
        Destroy(transform.root.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
