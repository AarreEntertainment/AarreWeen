﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{

    public Question question;
    public string questionText;
    public int CorrectAnswer;
    public List<string> answers;

    // Start is called before the first frame update
    public void Initiate()
    {
            questionText = question.QuestionText;
        
            List<string> quests = new List<string>() { question.CorrectAnswer, question.WrongAnswerOne, question.WrongAnswerTwo };
            List<string> allqs = new List<string>();

            while (quests.Count > 0)
            {
                int i = Random.Range(0, quests.Count - 1);
                allqs.Add(quests[i]);
                quests.RemoveAt(i);
            }
            answers = allqs;
            CorrectAnswer = answers.IndexOf(question.CorrectAnswer);
        
    }
    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    public bool CheckCorrect(int value)
    {
        if (CorrectAnswer == value)
        {
            StartCoroutine(Destruct());
            return true;
        }
        else { return false; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChangePage>() != null)
        {
            other.GetComponent<ChangePage>().Change(questionText, answers, this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ChangePage>() != null)
        {
            other.GetComponent<ChangePage>().Close();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}