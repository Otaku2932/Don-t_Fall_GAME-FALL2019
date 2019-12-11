using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerS : MonoBehaviour
{
    public float tutorial_length;
    public Text controlText;
    public Text finishText;
    public Text restartText;
    public Text elapsedText;
    private bool allowrestart;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        allowrestart = false;
        StartCoroutine(endTutor());
    }

    // Update is called once per frame
    void Update()
    {
        //errors from activating rez and fin methods from other scripts
        if (allowrestart)
        {
            controlText.gameObject.SetActive(false);
            elapsedText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart our game (3 methods) 
                // The old way. Do not use.
                // Application.LoadLevel("Game");
                // The new way
                // SceneManager.LoadScene("Game");
                // Reload the same scene. Everytime. Guaranteed.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            time += Time.deltaTime;
            elapsedText.text = "Time elapsed: " + Math.Round(Convert.ToDecimal(time), 2, MidpointRounding.AwayFromZero);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // QUIT THE GAME
            Application.Quit();
        }
    }
    IEnumerator endTutor()
    {
        yield return new WaitForSeconds(tutorial_length);
        controlText.gameObject.SetActive(false);
        elapsedText.gameObject.SetActive(true);
    }
    public void rez()
    {
        restartText.gameObject.SetActive(true);
        allowrestart = true;
    }
    public void fin()
    {
        finishText.gameObject.SetActive(true);
        allowrestart = true;
    }
}
