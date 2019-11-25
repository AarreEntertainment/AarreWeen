using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent JumpScareEvent;
    public GameObject ScarePosition;
    public GameObject Player;

    public AudioSource music;
    bool jumpScared = false;
    public GameObject Scent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindScent());
        StartCoroutine(ticker());
    }
    IEnumerator FindScent()
    {
        savedScentPosition = 0;
        yield return new WaitForSeconds(3);
        Scent = Player.GetComponent<LeaveTrace>().scents[Player.GetComponent<LeaveTrace>().scents.Count - 1];
    }

    public void FindTeleportSpot()
    {
        Vector3 loc = Vector3.zero;
        bool foundLoc = false;
        Vector3 pos = transform.position;

        while (!foundLoc)
        {
            if(Physics.Raycast(new Vector3(Random.value*150-75, 100, Random.value*150-75), Vector3.down, out RaycastHit hit, 300))
            {

                    if(Vector3.Distance(hit.point, Player.transform.position) > 25 && hit.collider.tag=="SoftGround")
                    {
                        foundLoc = true;
                        loc = hit.point;
                    }

            }
        }
        transform.position = loc;
        Debug.Log("Teleported from " + pos.ToString() + " to " + loc.ToString());
    }

    public void NextScent()
    {
        
        int ScentIndex = Player.GetComponent<LeaveTrace>().scents.IndexOf(Scent);
        if (ScentIndex != 0)
        {
            Scent = Player.GetComponent<LeaveTrace>().scents[Player.GetComponent<LeaveTrace>().scents.Count - 1];
        }
        else
        {
            Scent = Player;
        }
    }
    public float tickInterval;
    public bool show = false;
    public GameObject MapSphere;
    IEnumerator ticker()
    {
        yield return new WaitForSeconds(tickInterval);
        if(show)
            StartCoroutine(shower());
        StartCoroutine(ticker());
    }
    IEnumerator shower()
    {
        MapSphere.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        MapSphere.SetActive(false);
    }
    public Color deathColor;
    public string deathscene;
    public string currentscene;
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        SavedScenes.StartTransition(currentscene, deathscene, deathColor);
    }
    public void JumpScare()
    {
        if (jumpScared)
            return;
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().dead = true;   
        GetComponent<Animator>().SetFloat("Speed", 0);
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
        Vector3 offset = Player.transform.position - transform.position;
        transform.position = ScarePosition.transform.position;
        transform.LookAt(Player.transform.position);

        JumpScareEvent.Invoke();
        GetComponent<Animator>().SetTrigger("scream");
        jumpScared = true;
        StartCoroutine(ChangeScene());
    }
    int savedScentPosition = 0;
    // Update is called once per frame
    void Update()
    {
        if (jumpScared)
        {
            return;
        }
        GetComponent<Animator>().SetFloat("Speed", GetComponent<UnityEngine.AI.NavMeshAgent>().speed);
        if(Vector3.Distance(transform.position, Player.transform.position) < 100)
        {
            show = true;
            music.volume = 0.2f + 0.8f / Vector3.Distance(transform.position, Player.transform.position);
            tickInterval = 4-
                4 / Vector3.Distance(transform.position, Player.transform.position);

        }
        else
        {
            show = false;
            tickInterval = 1;
        }
        if (Scent != null) {
            GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(Scent.transform.position);
            int scentIndex = Player.GetComponent<LeaveTrace>().scents.IndexOf(Scent);
            if (scentIndex < savedScentPosition)
            {
                
                Scent = null;
                FindTeleportSpot();
                StartCoroutine(FindScent());
            }
            else
            {
                savedScentPosition = scentIndex;
            }
        }
    }
}
