using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string QuestionText;
    public string CorrectAnswer;
    public string WrongAnswerOne;
    public string WrongAnswerTwo;

    public int RelevantPaper;
}

[CreateAssetMenu(fileName = "QuestionList", menuName = "ScriptableObjects/QuestionList", order = 1)]
public class Questions : ScriptableObject
{
    public Question[] AllQuestions;
    [TextArea(5, 10)]
    public string[] AllPapers;
}
