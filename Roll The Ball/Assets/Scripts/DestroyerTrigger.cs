using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyerTrigger : MonoBehaviour
{
    public Text endText;
    void Start ()
    {
        endText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Test());
            other.gameObject.SetActive(false);
            endText.text = "Game Over!";
            Test();
        }
    }
    public IEnumerator Test()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("Level02");
    }
}
