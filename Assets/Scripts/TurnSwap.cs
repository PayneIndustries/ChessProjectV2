using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSwap : MonoBehaviour {

    public GameObject[] whitePieces;
    public GameObject[] blackPieces;
    public bool curPlayerWhite;

	// Use this for initialization
	void Start () {

        curPlayerWhite = true;

	}
	
	// Update is called once per frame
	void Update () {
        SwapTurn();
	}

    //Change the  Input to just be when the function is called
    //The function should only be called after a piece is moved
    public void SwapTurn()
    {
        if (Input.GetKeyDown(KeyCode.S) && curPlayerWhite)
        {
            foreach(GameObject i in whitePieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = !enabled;
            }

            foreach(GameObject i in blackPieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = enabled;
            }

            curPlayerWhite = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !curPlayerWhite)
        {
            foreach (GameObject i in whitePieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = enabled;
            }

            foreach (GameObject i in blackPieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = !enabled;
            }

            curPlayerWhite = true;
        }
    }
}
