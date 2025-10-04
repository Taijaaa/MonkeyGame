using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {

    }


    void Update()
    {
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene("Gameplay");
            }

            
            if (Input.GetKeyDown(KeyCode.I))
            {
                SceneManager.LoadScene("InformationScreen");
            }
        }
    }
}

