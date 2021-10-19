using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyerTrigger1 : MonoBehaviour
{
    //public Text endText;
    public Text uIText;
    void Start ()
    { 
        //uIText.text = "";
        //endText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(Test());
            other.gameObject.SetActive(false);
            uIText.text = "Game Over!";
            uIText.enabled = true;
            StartCoroutine(Test());
            uIText.enabled = false;
            //StartCoroutine(ShowMessage("Game Over!", 5 / 2));
            SceneManager.LoadScene("Level03");
            //endText.text = "Game Over!";
            //Test();
        }
    }
    public IEnumerator Test()
    {
        yield return new WaitForSecondsRealtime(5);
        //SceneManager.LoadScene("Level03");
    }
    /*public IEnumerator ShowMessage(string message, float delay)
    {
        uIText.text = message;
        uIText.enabled = true;
        yield return new WaitForSeconds(delay);
        uIText.enabled = false;
    }*/
}
