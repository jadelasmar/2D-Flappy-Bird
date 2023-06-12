using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pipes : MonoBehaviour
{
    public float speed;
    public float modifier;
    private float _random;

    public Transform initialPipe;

    public GameObject coin;
    public GameObject topPipe;
    public GameObject bottomPipe;

    void FixedUpdate()
    {
        if (GameManager.Instance.gameOver) return;
        transform.Translate(Vector2.left * GameManager.Instance.speed);
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EndPipe"))
        {
            transform.position = initialPipe.position;
            Reposition(Random.Range(0, 3));
            coin.SetActive(true);
        }
    }

    private void Reposition(int i)
    {
        switch (GameManager.Instance.difficulty)
        {
            case 0:
            case 1:
            {
                switch (i)
                {
                    case 0:
                        topPipe.SetActive(true);
                        bottomPipe.SetActive(false);
                        _random = Random.Range(3f, 5f);
                        topPipe.transform.position = new Vector2(topPipe.transform.position.x, _random);
                        coin.transform.position = new Vector2(coin.transform.position.x, Random.Range(-3, _random - 3));
                        break;

                    case 1:
                        topPipe.SetActive(false);
                        bottomPipe.SetActive(true);
                        _random = Random.Range(-5f, -3f);
                        bottomPipe.transform.position = new Vector2(bottomPipe.transform.position.x, _random);
                        coin.transform.position = new Vector2(coin.transform.position.x, Random.Range(_random + 3, 3));
                        break;

                    case 2:
                        topPipe.SetActive(true);
                        bottomPipe.SetActive(true);
                        _random = Random.Range(3f, 5f);
                        topPipe.transform.position = new Vector2(topPipe.transform.position.x, _random);
                        bottomPipe.transform.position = new Vector2(bottomPipe.transform.position.x, _random - 8);
                        coin.transform.position = new Vector2(coin.transform.position.x,
                            Random.Range(_random - 5, _random - 2));
                        break;
                }

                break;
            }

            case 2:
            case 3:
            case 4:
            {
                switch (i)
                {
                    case 0:
                        topPipe.SetActive(true);
                        bottomPipe.SetActive(false);
                        _random = Random.Range(1f, 3f);
                        topPipe.transform.position = new Vector2(topPipe.transform.position.x, _random);
                        coin.transform.position = new Vector2(coin.transform.position.x, Random.Range(-3, _random - 3));
                        break;

                    case 1:
                        topPipe.SetActive(false);
                        bottomPipe.SetActive(true);
                        _random = Random.Range(-3f, -1f);
                        bottomPipe.transform.position = new Vector2(bottomPipe.transform.position.x, _random);
                        coin.transform.position = new Vector2(coin.transform.position.x, Random.Range(_random + 3, 3));
                        break;

                    case 2:
                        topPipe.SetActive(true);
                        bottomPipe.SetActive(true);
                        _random = Random.Range(2f, 5f);
                        topPipe.transform.position = new Vector2(topPipe.transform.position.x, _random);
                        bottomPipe.transform.position = new Vector2(bottomPipe.transform.position.x, _random - 7);
                        coin.transform.position = new Vector2(coin.transform.position.x,
                            Random.Range(_random - 4, _random - 2));
                        break;
                }

                break;
            }

            case 5:
            case 6:
            case 7:
            case 8:
            {
                switch (i)
                {
                    case 0:
                        topPipe.SetActive(true);
                        bottomPipe.SetActive(false);
                        _random = Random.Range(0f, 1f);
                        topPipe.transform.position = new Vector2(topPipe.transform.position.x, _random);
                        coin.transform.position = new Vector2(coin.transform.position.x, _random - 3);
                        break;

                    case 1:
                        topPipe.SetActive(false);
                        bottomPipe.SetActive(true);
                        _random = Random.Range(-1f, 0f);
                        bottomPipe.transform.position = new Vector2(bottomPipe.transform.position.x, _random);
                        coin.transform.position = new Vector2(coin.transform.position.x, _random + 3);
                        break;

                    case 2:
                        topPipe.SetActive(true);
                        bottomPipe.SetActive(true);
                        _random = Random.Range(0f, 5f);
                        topPipe.transform.position = new Vector2(topPipe.transform.position.x, _random);
                        bottomPipe.transform.position = new Vector2(bottomPipe.transform.position.x, _random - 6);
                        coin.transform.position = new Vector2(coin.transform.position.x, _random - 3);
                        break;
                }

                break;
            }
        }
    }
}