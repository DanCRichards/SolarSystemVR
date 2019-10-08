using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuizQuestion> qq;


    public GameObject radial1;
    public GameObject radial2;
    public GameObject radial3;
    public GameObject radial4;
    public TextMeshPro questionText;
    private int questionNumber;
    private bool currentSelection;
    private int score;
    private bool quizFinished = false;

    private void Start()
    {
        //startQuiz();
    }
    // Start is called before the first frame update
    public void startQuiz()
    {
        CanvasApi.Start();
        string[] ans1 = new string[4] { "Pluto", "Mars", "Earth", "Mickey Mouse" };
        QuizQuestion qz1 = new QuizQuestion("What planet has a Disney character named after it?", ans1);
        //qq.Add(qz1);         
        // this.qq.Add(new QuizQuestion("What is the 3rd planet away from the sun?", new string[4] { "Earth", "Mars", "Jupiter", "Mercury" }));            
        //this.qq.Add(new QuizQuestion("What is the only other planet apart from Earth that has Acid rain?", new string[4] { "Venus", "Mars", "Uranus", "Neptune" }));

        radial1.SetActive(true);
        radial2.SetActive(true);
        radial3.SetActive(true);
        radial4.SetActive(true);

        questionText.GetComponent<TextMeshPro>().text = CanvasApi.getQuestionText(0);
        radial1.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(0);
        radial2.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(1);
        radial3.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(2);
        radial4.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(3);

        questionNumber = 1;
        score = 0;
    }


    public void previousQuestion()
    {
        if (questionNumber != 1)
        {
            questionNumber--;
            changeQuestion();
        }

    }

    public void changeQuestion()
    {
        switch (questionNumber)
        {
            case 1:
                questionText.GetComponent<TextMeshPro>().text = CanvasApi.getQuestionText(1);
                radial4.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(3);
                radial2.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(1);
                radial1.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(0);
                radial3.GetComponentInChildren<TextMesh>().text = CanvasApi.answer(2);
                questionNumber = 2;
                break;

            case 2:      
                questionText.GetComponent<TextMeshPro>().text = "Well done you completed the quiz and got: " + score;
                radial1.SetActive(false);
                radial2.SetActive(false);
                radial3.SetActive(false);
                radial4.SetActive(false);
                quizFinished = true;
                break;
        }

    }

    public void nextQuestion()
    {
        if (radial1.GetComponent<Interactable>().enabled)
        {
            score++;
        }
        if (!quizFinished)
        {
            changeQuestion();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
