using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//     	Developer Name: Zaryn Magtibay
//     	Contribution: This script takes care of the different funtionality of the buttons.
//     	Feature : Resume Button, Main Menu Button, and Quit Button.
//     	Start & End dates : 11/07/17 - 11/07/17
//            	References: No references were used
//                    	Links: NA

public class ButtonFunctions : MonoBehaviour {
    public Transform canvas;

    public void ResumeGame()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnMouseClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    

    public void QuitGame() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
