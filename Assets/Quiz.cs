using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public Questions questions;
    public string questionText;
    public int CorrectAnswer;
    public List<string> answers;
    // Start is called before the first frame update
    void Start()
    {
        Question q = questions.AllQuestions[Random.Range(0, questions.AllQuestions.Length - 1)];
        questionText = q.QuestionText;
        List<string> quests = new List<string>() { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo };
        List<string> allqs = new List<string>();

        while (quests.Count > 0)
        {
            int i = Random.Range(0, quests.Count - 1);
            allqs.Add(quests[i]);
            quests.RemoveAt(i);
        }
        answers = quests;
        CorrectAnswer = answers.IndexOf(q.CorrectAnswer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
