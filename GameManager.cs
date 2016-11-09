using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text ScoreBoard;
    public GameObject ball;
    public static bool AS = true;
    private int scoreP1 = 0;
    private int scoreP2 = 0;

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {

        if (ball.transform.position.x >= 14 && AS == true)
        {
            AS = false;
            scoreP1++;
        }
        if (ball.transform.position.x <= -14 && AS == true)
        {

            AS = false;
            scoreP2++;
        }
        if (scoreP1 >= 11)
        {
            SceneManager.LoadScene(2);
        }
        if (scoreP2 >= 11)
        {
            SceneManager.LoadScene(3);
        }
        print(scoreP1 + " - " + scoreP2);
        ScoreBoard.text = scoreP1.ToString() + " - " + scoreP2.ToString();

    }
}