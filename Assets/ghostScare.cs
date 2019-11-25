using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScare : MonoBehaviour
{
    delegate void ghostFunction();
    List<ghostFunction> ghostFuncs = new List<ghostFunction>();
    public List<GameObject> relevantGhosts;

    public void firstGhostEv()
    {
        Vector3 ret = Vector3.zero;
        Vector3 pos = transform.position+ transform.forward*15 + Vector3.up*4 + transform.right*(Random.value*2-1);
        if(Physics.Raycast(pos, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            ret = hit.point;
        }

        StartCoroutine(blink(ret));
    }

    IEnumerator blink(Vector3 position)
    {
        GameObject gamo = relevantGhosts[Random.Range(0, relevantGhosts.Count)];
        gamo.SetActive(true);
        gamo.transform.position = position;
        yield return new WaitForSeconds(0.05f);
        gamo.SetActive(false);
    }
    IEnumerator run(Vector3 position)
    {
        GameObject gamo = relevantGhosts[Random.Range(0, relevantGhosts.Count)];
        gamo.SetActive(true);
        gamo.transform.position = position;
        gamo.transform.LookAt(new Vector3((transform.forward * 60).x, gamo.transform.position.y, (transform.forward * 60).z));
        gamo.GetComponent<Animator>().SetBool("run", true);
        
        yield return new WaitForSeconds(3f);
        gamo.GetComponent<Animator>().SetBool("run", false);
        gamo.SetActive(false);
    }
    public void secondGhostEv()
    {
        Vector3 ret = Vector3.zero;
        Vector3 pos = transform.position + transform.forward*25 + Vector3.up * 4 + transform.right * (Random.Range((int)0,(int)2)*2-1)*20;
        if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            ret = hit.point;
        }

        StartCoroutine(run(ret));
    }
    // Start is called before the first frame update
    void Start()
    {
        ghostFunction first = firstGhostEv;
        ghostFuncs.Add(first);
        ghostFunction second = secondGhostEv;
        ghostFuncs.Add(second);


        StartCoroutine(timer());
    }

    IEnumerator timer() {
        yield return new WaitForSeconds(Random.value * 10);
        
        if(Random.value<(0.05f*(float)relevantGhosts.Count))
        ghostFuncs[Random.Range(0,ghostFuncs.Count)]();
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
