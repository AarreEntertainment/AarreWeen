using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrace : MonoBehaviour
{
    public List<GameObject> scents;
    public GameObject scentbase;
    IEnumerator LeaveScent() {
        if (scents.Count==0)
        {
            GameObject newscent;
            for(int i = 0; i < 5; i++)
            {
                newscent = Instantiate(scentbase);
                newscent.transform.position = transform.position;
                scents.Add(newscent);
            }
        }
        yield return new WaitForSeconds(6);
        GameObject currScent = scents[scents.Count - 1];
        scents.RemoveAt(scents.Count - 1);
        List<GameObject> replacementScents = new List<GameObject>();
        currScent.transform.position = transform.position;
        replacementScents.Add(currScent);
        replacementScents.AddRange(scents);
        scents = replacementScents;
        StartCoroutine(LeaveScent());
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LeaveScent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
