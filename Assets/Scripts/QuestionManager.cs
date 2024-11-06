using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

[System.Serializable]
public class Question
{
    // all the data for each question
    public string Vragen;
    public string AntwoordA;
    public string AntwoordB;
    public string AntwoordC;
    public string AntwoordD;
    public string JuisteAntwoord;
    public float punten;
}

[System.Serializable]
public class QuestionList
{
    // an array of questions so you can have multiple
    public Question[] question;
}

public class QuestionManager : MonoBehaviour
{
    [Header("Question Data")]
    public TextAsset QuestionData;      //JSON file
    public QuestionList questionManager = new QuestionList();       //the question list class


    [SerializeField] private TextMeshProUGUI QuestionText;      // text that shows the question in the UI
    [SerializeField] private TextMeshProUGUI[] anwsertext;      // Text for all the buttons that show possible anwsers to the question

    
    [HideInInspector] public string anwser;     // the input based on what anwser you gave
    [HideInInspector] public int questionIndex = 0;     // index for what question you are at
    private float Score;        // the amount of points you got

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI AnwserCorrect;     // the text for showing if your anwser is correct or not
    [SerializeField] private TextMeshProUGUI points;        // the text for showing the amount of points you got at the end of the test
    [SerializeField] private TextMeshProUGUI score;     // the text for showing the mark you got at the end of the test

    [Header("Pannel")]
    [SerializeField] private GameObject ResultPannel;   // pannel that shows the result of the test
    public GameObject QuestionPannel;       //pannel that shows the questions
    public GameObject anwsercheckPannel;        //pannel that shows if your anwser was correct or not

    void Start()
    {
        // Get all the question data from json to unity
        questionManager = JsonUtility.FromJson<QuestionList>(QuestionData.text);
        GetQuestion();
    }

    /// <summary>
    /// function for the question visualisation in UI with the correct anwser options.
    /// </summary>
    public void GetQuestion()
    {
        // question text
        QuestionText.text = questionManager.question[questionIndex].Vragen;

        //Anwser A-D text
        anwsertext[0].text = questionManager.question[questionIndex].AntwoordA;
        anwsertext[1].text = questionManager.question[questionIndex].AntwoordB;
        anwsertext[2].text = questionManager.question[questionIndex].AntwoordC;
        anwsertext[3].text = questionManager.question[questionIndex].AntwoordD;
    }

    /// <summary>
    /// function to check if the anwser is correct
    /// </summary>
    public void CheckAnwser()
    {
        // if the anwser is correct get the correct amount of points
        if (anwser == questionManager.question[questionIndex].JuisteAntwoord)
        {
            Score += questionManager.question[questionIndex].punten;

            AnwserCorrect.text = $"Correct";
        }
        else
        {
            AnwserCorrect.text = $"Wrong";
        }
    } 

    /// <summary>
    /// when you anwsered all the questions you get to see your score through this function
    /// </summary>
    public void Result()
    {
        // enebaling the correct pannel in the UI
        ResultPannel.SetActive(true);
        QuestionPannel.SetActive(false);
        anwsercheckPannel.SetActive(false);

        // here you show how many point you got
        points.text = $"You got {Score} points";

        //calculate your mark based on the amount of points you got
        float mark;
        mark = Score * 10 / 8;

        score.text = $"Which is a {mark}";
    }
}
