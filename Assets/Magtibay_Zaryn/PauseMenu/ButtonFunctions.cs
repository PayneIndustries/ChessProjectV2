using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
