using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController01 : MonoBehaviour
{
    public float Speed;
    public Text scoreText;
    public Text timeText;
    public Text winText;
    private Rigidbody rb;
    private int score;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        score = 0;
        winText.text = "";
        SetScoreText();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);
        //SetTimeText();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }

    }
    void SetScoreText()
    {
        
        scoreText.text = "Score: " + score.ToString();
        if (score == 13)
        {
            StartCoroutine(Test());
            winText.text = "You Win!";
            Test();
            
        }
    }
    /*void SetTimeText()
    {

        float time = Time.time;
        timeText.text = "Time: " + time.ToString();
    }*/
    public IEnumerator Test()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("Level02");
    }
}