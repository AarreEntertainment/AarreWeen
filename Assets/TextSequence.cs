using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSequence : MonoBehaviour
{
    public float LetterWaitTime;
    public float LineWaitTime;
    public float lineLimit;
    [Multiline]
    public string readabletext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeLetter());
    }

    int index = 0;
    int totalLines;
    IEnumerator TypeLetter()
    {
        bool lineChange = readabletext[index] == '\n';

        yield return new WaitForSeconds(lineChange ? LineWaitTime: LetterWaitTime);
        if (lineChange)
        {
            totalLines++;
            string edText = GetComponent<UnityEngine.UI.Text>().text;
            if (edText.IndexOf('\n') > -1 && totalLines >= lineLimit) 
            {
                List<string> eds = new List<string>(edText.Split('\n'));
                eds.RemoveAt(0);
                totalLines -= 1;
                GetComponent<UnityEngine.UI.Text>().text = string.Join("\n", eds.ToArray());
            }

        }
        GetComponent<UnityEngine.UI.Text>().text+= readabletext[index];
        GetComponent<AudioSource>().Play();
        index++;
        if (index < readabletext.Length)
        {
            StartCoroutine(TypeLetter());
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
