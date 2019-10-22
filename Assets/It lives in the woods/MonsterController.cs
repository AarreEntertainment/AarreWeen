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
        StartCoroutine(findScent());
    }
    IEnumerator findScent()
    {
        yield return new WaitForSeconds(2);
        Scent = Player.GetComponent<LeaveTrace>().scents[Player.GetComponent<LeaveTrace>().scents.Count - 1];
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
    public void JumpScare()
    {
        transform.LookAt(Player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        transform.position = ScarePosition.transform.position;
        JumpScareEvent.Invoke();
        GetComponent<Animator>().SetTrigger("scream");
        jumpScared = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpScared)
            return;
        GetComponent<Animator>().SetFloat("Speed", GetComponent<UnityEngine.AI.NavMeshAgent>().speed);
        if(Vector3.Distance(transform.position, Player.transform.position) < 50) { music.volume = 0.5f + 0.5f / Vector3.Distance(transform.position, Player.transform.position); }
        if (Scent != null) { GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(Scent.transform.position); }
    }
}
