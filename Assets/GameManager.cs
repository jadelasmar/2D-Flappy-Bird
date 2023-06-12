using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    public int difficulty;
   [SerializeField] private int oldDifficulty;
    public int speed;
    public Transform pipes;
    public Transform initialPipe;

    private void Awake()
    {
        difficulty = oldDifficulty = 0;
        Instance = this;
        speed = 1;
    }

    public void AddScore()
    {
        score++;
        
        difficulty = score / 5;
        
        Debug.Log("difficulty : "+difficulty+" and speed :"+speed);

        if (oldDifficulty == difficulty) return;
        oldDifficulty = difficulty;
            
        switch (difficulty)
        {
            default:
                speed++;
                break;
            
            case 2:
            case 5:
                break;
        }
    }


    public static void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}