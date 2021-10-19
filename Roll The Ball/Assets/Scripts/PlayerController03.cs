using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController03 : MonoBehaviour
{
    public float Speed;
    public Text scoreText;
    public Text timeText;
    //public Text winText;
    public Text uIText;
    private Rigidbody rb;
    private int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        //winText.text = "";
        //uIText.text = "";
        SetScoreText();
        uIText.text = "Level 3";
        uIText.enabled = true;
        StartCoroutine(Test());
        uIText.enabled = false;
        //StartCoroutine(ShowMessage("Level 3", 5 / 2));

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Bonus"))
        {
            other.gameObject.SetActive(false);
            score += 2;
            SetScoreText();
        }
        if(other.gameObject.CompareTag("Trigger"))
        {
            SceneManager.LoadScene("Level03");
        }

    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 60)
        //if (score >= 60 && score < 100)
        {
            uIText.text = "You Win!";
            uIText.enabled = true;
            StartCoroutine(Test());
            uIText.enabled = false;
            uIText.text = "Congratulations! You Completed The Game";
            uIText.enabled = true;
            StartCoroutine(Test());
            uIText.enabled = false;
            uIText.text = "Loading Level 1";
            uIText.enabled = true;
            StartCoroutine(Test());
            uIText.enabled = false;
            //winText.text = "You Win!";
            /*StartCoroutine(ShowMessage("You Win!", 5 / 2));
            StartCoroutine(ShowMessage("Congratulations! You Completed The Game", 5 / 2));
            StartCoroutine(ShowMessage("Loading Level 1", 5 / 2));*/
            SceneManager.LoadScene("Level01");
        }
        if (score == 100)
        {
            //StartCoroutine(ShowMessage("Bonus Level Unlocked!", 5));
            uIText.text = "Bonus Level Unlocked";
            uIText.enabled = true;
            StartCoroutine(Test());
            uIText.enabled = false;
            SceneManager.LoadScene("Bonus Level");
        }
    }
    public IEnumerator Test()
    {
        yield return new WaitForSecondsRealtime(5/2);
        //SceneManager.LoadScene("Level01");
    }
    /*public IEnumerator ShowMessage(string message, float delay)
    {
        uIText.text = message;
        uIText.enabled = true;
        yield return new WaitForSeconds(delay);
        uIText.enabled = false;
    }*/
}

