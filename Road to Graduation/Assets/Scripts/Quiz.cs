using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [System.Serializable]
    public struct choices
    {
        public string[] choice;
    }

    GameObject quiz, quizObj, indexObj, questionObj, choiceObj, nameObj, personObj, backgroundObj;
    public string[] name;
    public string[] question;
    public string[] person;
    public choices[] choice = new choices[4];
    public int[] answer;

    int currentIndex;

    void Start()
    {
        quiz = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Quiz.prefab", typeof(GameObject));
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player" && !GameObject.Find("/Quiz"))
        {
            Debug.Log("quiz");
            quizObj = Instantiate(quiz, transform.position, Quaternion.identity);
            quizObj.name = "Quiz";
            backgroundObj = GameObject.Find("/Quiz/Background");
            backgroundObj.GetComponent<Image>().sprite = GameObject.Find("/Background").GetComponent<SpriteRenderer>().sprite;
            currentIndex = -1;
            nextQuiz();
        };
    }

    void Update()
    {
        if (GameObject.Find("/Quiz"))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                chooseAnswer(1);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                chooseAnswer(2);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                chooseAnswer(3);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                chooseAnswer(4);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                nextQuiz();
            }
        }
    }

    public void chooseAnswer(int chose)
    {
        if (chose == answer[currentIndex])
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
        nextQuiz();
    }

    public void nextQuiz()
    {
        currentIndex++;
        if (currentIndex < question.Length)
        {
            questionObj = GameObject.Find("/Quiz/Question Box/Question");
            questionObj.GetComponent<Text>().text = question[currentIndex];
            nameObj = GameObject.Find("/Quiz/Name Box/Name");
            nameObj.GetComponent<Text>().text = name[currentIndex];
            personObj = GameObject.Find("/Quiz/Character");
            personObj.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Assets/Dialogue/Character/Engine.png", typeof(Sprite));
            indexObj = GameObject.Find("/Quiz/Question Index/Index");
            indexObj.GetComponent<Text>().text = "Q" + (currentIndex + 1);
            for (int i = 1; i < 5; i++)
            {
                choiceObj = GameObject.Find("/Quiz/Choices/" + i);
                choiceObj.GetComponent<Text>().text = choice[currentIndex].choice[i - 1];
            }
        }
        else
        {
            closeQuiz();
        }
    }

    public void closeQuiz()
    {
        quizObj = GameObject.Find("/Quiz");
        Destroy(quizObj);
    }
}
