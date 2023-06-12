using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public Transform initialTree;
    public float speed;
    public float modifier;
    
    void FixedUpdate()
    {
        if (GameManager.Instance.gameOver) return;
        transform.Translate(Vector2.left * GameManager.Instance.speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EndPipe"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = Random.Range(0, 3) == 0;
            transform.position = new Vector2(initialTree.position.x+Random.Range(0,10),transform.position.y) ;
        }
    }
}
