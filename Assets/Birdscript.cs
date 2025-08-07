using System.Net;
using UnityEngine;

public class Birdscript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float flyup = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rigidbody.linearVelocity = Vector2.up * flyup;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pipe"))
        {
            GameManager.instance.GameOver();
        }
        else if (collision.gameObject.CompareTag("score"))
        {
            GameManager.instance.IncreaseScore();
        }
        else if (collision.gameObject.CompareTag("Cloud"))
        {
            GameManager.instance.GameOver();
        }
    }
}

