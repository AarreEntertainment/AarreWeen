using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePage : MonoBehaviour
{
    public GameObject panel;
    public Text PageText;
    public Text Answer1Text;
    public Text Answer2Text;
    public Text Answer3Text;
    public Quiz quiz;
    public Image panelImage;
    public GameObject gravestone;
    public GameObject page;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckCorrect(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckCorrect(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckCorrect(2);
        }
    }
    public void CheckCorrect(int value)
    {
        if (quiz.CheckCorrect(value))
        {
            panel.SetActive(false);
        }
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Change(string pageText, List<string> answers = null, Quiz quizobj = null)
    {
        panel.SetActive(true);
        PageText.text = pageText;
        if(quizobj != null)
        {
            gravestone.SetActive(true);
            page.SetActive(false);
            Answer1Text.gameObject.SetActive(true);
            Answer2Text.gameObject.SetActive(true);
            Answer3Text.gameObject.SetActive(true);
            Answer1Text.text = answers[0];
            Answer2Text.text = answers[1];
            Answer3Text.text = answers[2];
            quiz = quizobj;
        }
        else
        {
            gravestone.SetActive(false);
            page.SetActive(true);
            Answer1Text.gameObject.SetActive(false);
            Answer2Text.gameObject.SetActive(false);
            Answer3Text.gameObject.SetActive(false);
            Answer1Text.text = "";
            Answer2Text.text = "";
            Answer3Text.text = "";
        }
        
    }
}
