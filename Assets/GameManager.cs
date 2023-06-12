using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    public int difficulty;
   [SerializeField] private int oldDifficulty;
    public float speed;
    public float speedAcc;
    public Transform tree;
    public bool gameOver;
    public GameObject gameOverImage;
    public TextMeshProUGUI scoreLeft;

    private void Awake()
    {
        difficulty = oldDifficulty = 0;
        Instance = this;
    }

    private void FixedUpdate()
    {
        speed += speedAcc * Time.deltaTime;
        Debug.Log(speed);

    }

    public void AddScore()
    {
        score++;
        scoreLeft.text = score.ToString();  
        difficulty = score / 5;

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public  void GameOver()
    {
        gameOver = true;
        Invoke(nameof(GameDone),3f);
        
    }

    public void GameDone()
    {
        gameOverImage.SetActive(true);
    }
}