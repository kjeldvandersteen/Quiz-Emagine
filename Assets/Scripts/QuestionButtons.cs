using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButtons : MonoBehaviour
{
    private QuestionManager questionManager;

    private void Start()
    {
        questionManager = GetComponent<QuestionManager>();
    }

    /// <summary>
    /// anwser A
    /// </summary>
    public void A()
    {
            questionManager.anwser = "A";
            questionManager.CheckAnwser();
    }
    /// <summary>
    /// anwser B
    /// </summary>
    public void B()
    {
            questionManager.anwser = "B";
            questionManager.CheckAnwser();
    }
    /// <summary>
    /// anwser C
    /// </summary>
    public void C()
    {
            questionManager.CheckAnwser();
            questionManager.anwser = "C";
    }
    /// <summary>
    /// anwser D
    /// </summary>
    public void D()
    {
            questionManager.anwser = "D";
            questionManager.CheckAnwser();
    }

    /// <summary>
    /// going to the next round or result based on what question you are at
    /// </summary>
    public void NextQuestion()
    {

        // if the question index is at the last question you are at the end of the test so you get to see your result
        if (questionManager.questionIndex == questionManager.questionManager.question.Length - 1)
        {
            questionManager.Result();
            questionManager.anwsercheckPannel.SetActive(false);
        }
        else
        {
            questionManager.questionIndex += 1;
            questionManager.GetQuestion();
            questionManager.QuestionPannel.SetActive(true);
            questionManager.anwsercheckPannel.SetActive(false);
        }
    }
}
