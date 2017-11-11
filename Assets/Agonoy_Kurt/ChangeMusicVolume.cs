using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

 /* 
// Developer Name: Kurt Agonoy
// Contributions: 
// Slider UI is tagged to the Pause Screen 
and can either raise or lower the volume of the back ground music

// 11/8/17-11/10/17
// Reference: None
// Links: NA
*/
    public Slider Volume;
	public AudioSource Music;

	// Update is called once per frame
	void Update () {
		Music.volume = Volume.value;
	}
}
