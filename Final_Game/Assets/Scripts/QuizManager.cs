using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;

    private List<Question> questions;
    private Question selectedQuestion;
    // Start is called before the first frame update
    void Start()
    {
        questions = quizData.questions;
        SelectQuestion();
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);
    }
    public bool Answer(string answered)
    {
        bool correctAns = false;

        if (answered == selectedQuestion.correctAns) 
        {
            //YES
            correctAns = true;
        }
        else
        {
            //NO
        }
        Invoke("SelectQuestion", 0.4f);

        return correctAns;
    }
   
}
[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite qustionImg;
    public AudioClip qustionClip;
    public UnityEngine.Video.VideoClip qustionVideo;
    public List<string> option;
    public string correctAns;
}

public enum QuestionType
{
    TEXT,IMAGE,VIDEO,AUDIO
}
