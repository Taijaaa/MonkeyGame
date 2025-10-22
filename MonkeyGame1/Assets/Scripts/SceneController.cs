using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // MAIN MENU CONTROLS
        if (currentScene == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Instructions");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene("Gameplay");
            }
        }

        // INSTRUCTIONS CONTROLS
        else if (currentScene == "Instructions")
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene("Gameplay");
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        // GAMEPLAY CONTROLS
        else if (currentScene == "Gameplay")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        // HIGH SCORE SCREEN

        else if (currentScene == "HighScoreScene")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Gameplay");
                
            }
            Debug.Log(currentScene);
        }



    }
}
