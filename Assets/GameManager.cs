using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreTextUi; 
    public Text GameOverTextUi;
    public Button PlayButton;
    public PipeCreatorsScript pipeCreators;
    private static bool isRestarting = false;
    public float pipespeed = 5f;
    private float initiaPipespeed = 5f;
    public float speedIncreaseAmount = 0.2f;
    private int Score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayButton.gameObject.SetActive(false);
        GameOverTextUi.gameObject.SetActive(false);

        if (isRestarting)
        {
            Time.timeScale = 1f;
            isRestarting = false;
        }
        else
        {
            Debug.Log("Game Start");
            Pause();
        }

        scoreTextUi.text = Score.ToString();
    }   
    public void Pause()
    {
        Time.timeScale = 0f;
        PlayButton.gameObject.SetActive(true);

    }
    public void Play()
    {
        isRestarting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void IncreaseScore()
    {
        Score++;
        scoreTextUi.text = Score.ToString();
        pipespeed += speedIncreaseAmount;
        Debug.Log("Score: " + Score + ", New Pipe Speed; " + pipespeed);

        if (Score % 5 == 0 && pipeCreators.spawnTime > 0.8f)
        {
            pipeCreators.spawnTime -= 0.3f;
        }
    }
    public void GameOver()
    {
        Debug.Log("Game Over");

        GameOverTextUi.gameObject.SetActive(true);
        Pause();
    }
}
