using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class QuestionController : MonoBehaviour
{
    public Text questionText;

    public Text answers1Text;

    public Text answers2Text;

    public Text answers3Text;

    public Text answers4Text;

    private int goodAnswerCheck;

    public TextAsset textJson;

    [System.Serializable]
    public class Questions
    {
        public string question;

        public string answer1;

        public string answer2;

        public string answer3;

        public string answer4;

        public int goodAnswer;
    }

    [System.Serializable]
    public class QuestionsList
    {
        public Questions[] questions;
    }

    public QuestionsList questionsList = new QuestionsList();

    void Start()
    {
        questionsList = JsonUtility.FromJson<QuestionsList>(textJson.text);
    }

    private bool state = true;

    private int cnt = 0;

    private int point = 0;

    // Update is called once per frame
    void Update()
    {
        if (state && cnt < 5)
        {
            questionText.text = questionsList.questions[cnt].question;
            answers1Text.text = questionsList.questions[cnt].answer1;
            answers2Text.text = questionsList.questions[cnt].answer2;
            answers3Text.text = questionsList.questions[cnt].answer3;
            answers4Text.text = questionsList.questions[cnt].answer4;
            state = false;
        }
        cnt++;
        if(cnt == 5){
            SceneManager.LoadScene("MainMenu");  
        }
    }

    public void checkAnswer(int number)
    {
        state = true;
        if (questionsList.questions[cnt].goodAnswer == number && cnt < 5)
        {
            point += 1;
        }
    }
}
