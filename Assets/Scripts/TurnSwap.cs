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
        
	}

    //Change the  Input to just be when the function is called
    //The function should only be called after a piece is moved
    public void SwapTurn()
    {
        if (curPlayerWhite)
        {
            foreach (GameObject i in whitePieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = enabled;
                i.layer = LayerMask.NameToLayer("Default");
            }

            foreach (GameObject i in blackPieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = !enabled;
                i.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
        }
        else if (!curPlayerWhite)
        {
            foreach (GameObject i in whitePieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = !enabled;
                i.layer = LayerMask.NameToLayer("Ignore Raycast");
            }

            foreach (GameObject i in blackPieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = enabled;
                i.layer = LayerMask.NameToLayer("Default");
            }
        }
    }
}