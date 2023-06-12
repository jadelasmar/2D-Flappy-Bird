using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float force;
    private Rigidbody2D _rb;
    private Animator _anim;
    private static readonly int Fly = Animator.StringToHash("fly");
    private static readonly int Hit = Animator.StringToHash("hit");


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.gameOver)
            ClickFly();
        else
            _anim.SetBool(Fly, false); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PipeScore"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.AddScore();
        }
    }

    private void ClickFly()
    {
        _rb.velocity = Vector2.up * force;
        _anim.SetBool(Fly, true);
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Pipe"))
        {
            _anim.SetBool(Hit, true);
            GameManager.Instance.GameOver();
        }
    }
}