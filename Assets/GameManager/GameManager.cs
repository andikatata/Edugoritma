using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestion;
    private Question currentQuestion;
    [SerializeField]
    private Text factText;
    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float timeBetweenQuestion = 1f;
	// Use this for initialization
	void Start () {
        if (unansweredQuestion == null || unansweredQuestion.Count == 0) {
            unansweredQuestion = questions.ToList<Question>();
        }
        SetCurrentQuestion();
	}

    void SetCurrentQuestion() {
        int randomQuestionIndex = Random.Range(0, unansweredQuestion.Count);
        currentQuestion = unansweredQuestion[randomQuestionIndex];
        unansweredQuestion.RemoveAt(randomQuestionIndex);
        factText.text = currentQuestion.fact;
        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "CORRECT !";
            trueAnswerText.color = Color.blue;
            falseAnswerText.text = "WRONG !";
            falseAnswerText.color = Color.red;
        }
        else {
            trueAnswerText.text = "WRONG !";
            trueAnswerText.color = Color.red;
            falseAnswerText.text = "CORRECT !";
            falseAnswerText.color = Color.blue;
        }
    }

    IEnumerator TransitionToNextQuestion() {
        unansweredQuestion.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UserSelectTrue() {
        animator.SetTrigger("True");
        
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT !");
        }
        else {
            Debug.Log("FALSE !");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT !");
        }
        else
        {
            Debug.Log("FALSE !");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    void keyBack()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
                return;
            }

        }
    }
    public void Back() {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update () {
        keyBack();
	}
}
