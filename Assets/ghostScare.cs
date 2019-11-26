using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScare : MonoBehaviour
{

    
    public float stress;
    delegate void ghostFunction();
    List<ghostFunction> ghostFuncs = new List<ghostFunction>();
    
    public List<GameObject> relevantGhosts;

    public GameObject tentacle;

    void tentacleAppear()
    {
    
        Vector3 pos = transform.position + transform.forward * (10+Random.value*4) + Vector3.up * 4 + transform.right * (Random.value * 2 - 1);
        if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            GameObject tent = Instantiate(tentacle);
            tent.transform.position = hit.point;
        }

    }

    

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
        stress += 1;
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
        stress += 2;
    }

    IEnumerator cloud(Vector3 position)
    {
        GameObject gamo = relevantGhosts[Random.Range(0, relevantGhosts.Count)];
        gamo.SetActive(true);
        int amt = Random.Range(1, 11);
        for(int i = 0; i < amt; i++)
        {
            gamo.transform.position = position + Vector3.forward * (Random.value * 10) + Vector3.left * ((Random.value * 20) - 10);
            yield return new WaitForSeconds(0.02f);
        }
        stress += 4;
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
        yield return new WaitForSeconds(Random.value * 8);

        if (Random.value < (0.1f * (float)relevantGhosts.Count))
        {
            ghostFuncs[Random.Range(0, ghostFuncs.Count)]();
        }
        if(stress>0)
            tentacleAppear();
        
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(stress>0)
            stress -= Time.deltaTime / 2;
    }
}
