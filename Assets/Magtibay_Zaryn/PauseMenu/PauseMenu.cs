using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//     	Developer Name: Zaryn Magtibay
//     	Contribution: I created the functionality of this pause menu. When the pause menu is activated, time in unity is stopped.
//     	Feature : Pause Menu
//     	Start & End dates : 11/07/17 - 11/07/17
//            	References: No references were used
//                    	Links: NA

public class PauseMenu : MonoBehaviour {
    public Transform canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
                if (canvas.gameObject.activeInHierarchy == false)
                {
                    canvas.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    canvas.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
        }
	}
}
