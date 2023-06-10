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
            case 1:
                speed = 2;
                break;

            case 2:
                break;
                
            case 3:
                AddObstacle();
                break;

            case 4:
                speed = 3;
                break;

            case 5:
                break;
                
            case 6:
                AddObstacle();
                break;

            case 7:
                speed = 4;
                break;
                
            default:
                speed++;
                break;
        }
    }

    private void AddObstacle()
    {
        for (var i = 0; i < pipes.childCount; i++)
        {
            if (pipes.GetChild(i).gameObject.activeSelf) continue;
            pipes.GetChild(i).gameObject.SetActive(true);
            initialPipe.position = new Vector2(initialPipe.position.x+10, initialPipe.position.y);
            break;

        }
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}