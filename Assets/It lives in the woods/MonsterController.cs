﻿using System.Collections;
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
        yield return new WaitForSeconds(5);
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

    public void JumpScare()
    {
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().dead = true;   
        GetComponent<Animator>().SetFloat("Speed", 0);
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
        Vector3 offset = Player.transform.position - GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).position;
        GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).LookAt(Player.transform.position);
        transform.position = ScarePosition.transform.position;
        JumpScareEvent.Invoke();
        GetComponent<Animator>().SetTrigger("scream");
        jumpScared = true;
        
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
            tickInterval = 4 / Vector3.Distance(transform.position, Player.transform.position);

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
                StartCoroutine(FindScent());
            }
            else
            {
                savedScentPosition = scentIndex;
            }
        }
    }
}
