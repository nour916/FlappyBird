using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 5f;
    public float flapForce = 20f;
    bool isDead;
    public GameObject restartButton;
    public GameObject startButton;
    int score = 0;
    public Text scoreText; 

    // Start is called before the first frame update
    void Start()
    {
        startButton.SetActive(true);
        restartButton.SetActive(false);
        Time.timeScale = 0;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb2d.velocity = Vector2.right * speed;
            rb2d.AddForce(Vector2.up * flapForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        GetComponent<Animator>().SetBool("isDead", true);
        restartButton.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Score")
        {
            score++;
            Debug.Log(score);
            scoreText.text = score.ToString();
        }
    }

    public void Unfreeze()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

