using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEntity : MonoBehaviour
{
    public Questions questions;
    public List<int> requiredPages;
    public int TombStonesToPlace;
    public GameObject Tombstone;
    public GameObject Page;
    public float radius;


    void Start()
    {
    }
    void load() { 
        int placedTombStones = 0;
        List<Question> Nuquestions = new List<Question>();
        Nuquestions.AddRange(questions.AllQuestions);
        while (placedTombStones < TombStonesToPlace)
        {
            
            if(Physics.Raycast(new Vector3(Random.Range(-radius, radius), transform.position.y, Random.Range(-radius, radius)), Vector3.down, out RaycastHit hit, 500))
            {
                if (hit.collider.tag == "SoftGround")
                {
                    GameObject tomb = Instantiate(Tombstone);
                    int ind = Random.Range(0, Nuquestions.Count - 1);
                    tomb.transform.SetPositionAndRotation(hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                    Question question = Nuquestions[ind];
                    Nuquestions.RemoveAt(ind);
                    tomb.GetComponent<Quiz>().question = question;
                    tomb.GetComponent<Quiz>().Initiate(this);

                    if (requiredPages.IndexOf(tomb.GetComponent<Quiz>().CorrectAnswer)==-1){
                        requiredPages.Add(tomb.GetComponent<Quiz>().CorrectAnswer);
                    }
                    placedTombStones++;
                }
            }
        }
        for (int i = 0; i < requiredPages.Count; i++)
        {
            bool placed = false;
            while (!placed)
            {
                if (Physics.Raycast(new Vector3(Random.Range(-radius, radius), transform.position.y, Random.Range(-radius, radius)), Vector3.down, out RaycastHit hit, 500))
                {
                    if (hit.collider.tag == "SoftGround")
                    {
                        placed = true;
                        GameObject thispage = Instantiate(Page);
                        thispage.transform.SetPositionAndRotation(hit.point, Quaternion.Euler(hit.normal));
                        thispage.GetComponent<PageEntity>().Page = questions.AllPapers[requiredPages[i]];
                    }
                }
            }
        }

        
    }
    bool activated = false;
    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "itlives" && !activated)
        {
            activated = true;
            load();
        }
    }
}
