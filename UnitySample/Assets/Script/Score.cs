using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    private Text scoreText;
    public int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
        if(score >= 2500)
        {
            SceneManager.LoadScene("Win");
        }

    }

    public void ScoreUP()
    {
        score += 100;
    }
}
