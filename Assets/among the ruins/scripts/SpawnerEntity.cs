using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEntity : MonoBehaviour
{
    public Questions questions;
    public List<int> requiredPages;
    public int TombStonesToPlace;
    public GameObject Page;

    public GameObject[] tombstones;
    public Transform[] pageLocations;
    void Start()
    {
    }

    void load()
    {

        /*   List<Question> Nuquestions = new List<Question>();
           Nuquestions.AddRange(questions.AllQuestions);
           TombStonesToPlace = tombstones.Length;
           for (int i =0;i<tombstones.Length;i++)
           {
               bool noDuplicates = false;
               int ind = 0;
               Question question = null;

               while (!noDuplicates)
               {
                   ind = Random.Range(0, Nuquestions.Count - 1);
                   question = Nuquestions[ind];
                   if (requiredPages.IndexOf(question.RelevantPaper) == -1)
                   {
                       noDuplicates = true;
                   }
               }
               Debug.Log("tombstone added");

               tombstones[i].GetComponent<Quiz>().question = question;
               tombstones[i].GetComponent<Quiz>().Initiate(this);
               Nuquestions.RemoveAt(ind);

               if (requiredPages.IndexOf(tombstones[i].GetComponent<Quiz>().question.RelevantPaper)==-1){
                   requiredPages.Add(tombstones[i].GetComponent<Quiz>().question.RelevantPaper);
               }
           }
           List<Transform> locs = new List<Transform>(pageLocations);
           for (int i = 0; i < requiredPages.Count; i++)
           {
               int j = Random.Range(0, locs.Count);
               GameObject thispage = Instantiate(Page);
               thispage.transform.SetPositionAndRotation(locs[j].position, Quaternion.Euler(new Vector3(0, Random.Range(0,360),0)));
               locs.RemoveAt(j);
               thispage.GetComponent<PageEntity>().Page = questions.AllPapers[requiredPages[i]];
           }*/

        List<string> pages = new List<string>();
        List<Transform> locs = new List<Transform>();
        pages.AddRange(questions.AllPapers);
        locs.AddRange(pageLocations);

        int val = pages.Count;
        for (int i = 0; i < val; i++)
        {
            int pagerand = Random.Range(0, pages.Count);
            int locrand = Random.Range(0, locs.Count);
            GameObject thispage = Instantiate(Page);
            thispage.GetComponent<PageEntity>().Page = pages[pagerand];
            thispage.transform.SetPositionAndRotation(locs[locrand].position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            pages.RemoveAt(pagerand);
            locs.RemoveAt(locrand);
            //Debug.Log(i);
        }
    }
    bool activated = false;
    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "ruins" && !activated)
        {
            activated = true;
            load();
        }
    }
}
