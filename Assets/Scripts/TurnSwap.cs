using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSwap : MonoBehaviour {

    public List<GameObject> whitePieces;
    public List<GameObject> blackPieces;
    public bool curPlayerWhite;
    public bool wasInstantiated;

    //         Developer Name: Ryan Wilson
    //         Contribution: Wrote the script for the Turn Swap.
    //         Feature : Made this to access turnSwap position.
    //         Start & End dates : 10/28/17 - 10/30/17

    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I wrote the script.
    //         Feature : Rewrote turnSwap to fix bugs and added 2 checks for check function.
    //         Start & End dates : 10/28/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA


    // Use this for initialization
    void Start () {

        curPlayerWhite = true;
        SwapTurn();
        wasInstantiated = false;

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
                i.tag = "Pawn";
                i.layer = LayerMask.NameToLayer("Default");
            }

            foreach (GameObject i in blackPieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = !enabled;
                i.tag = "Pawn";
                i.layer = LayerMask.NameToLayer("Ignore Raycast");
            }

        }
        else if (!curPlayerWhite)
        {
            foreach (GameObject i in whitePieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = !enabled;
                i.tag = "Pawn";
                i.layer = LayerMask.NameToLayer("Ignore Raycast");
            }

            foreach (GameObject i in blackPieces)
            {
                i.GetComponent<HighlightScript>().isEnabled = enabled;
                i.tag = "Pawn";
                i.layer = LayerMask.NameToLayer("Default");
            }

        }

        wasInstantiated = true;

    }
    public void CheckWhoIsInCheck()
    {
        if(curPlayerWhite != true)
        {
            JR_KingPawn king;
            GameObject kingPawn;
            foreach(GameObject i in blackPieces)
            {
                kingPawn = i;
                king = kingPawn.GetComponent<JR_KingPawn>();

                if (king != null)
                {
                    king.IsInCheck = true;
                    king.Check();
                }
            }
        }
        else
        {
            JR_KingPawn king;
            GameObject kingPawn;
            foreach (GameObject i in whitePieces)
            {
                kingPawn = i;
                king = kingPawn.GetComponent<JR_KingPawn>();
                if (king != null)
                {
                    king.IsInCheck = true;
                    king.Check();
                }
            }
        }
    }

    public void UnCheckWhoIsInCheck()
    {
        if (curPlayerWhite != true)
        {
            JR_KingPawn king;
            GameObject kingPawn;
            foreach (GameObject i in blackPieces)
            {
                kingPawn = i;
                king = kingPawn.GetComponent<JR_KingPawn>();
                if (king != null)
                {
                    king.IsInCheck = false;
                    king.UnCheck();
                }
            }
        }
        else
        {
            JR_KingPawn king;
            GameObject kingPawn;
            foreach (GameObject i in whitePieces)
            {
                kingPawn = i;
                king = kingPawn.GetComponent<JR_KingPawn>();
                if (king != null)
                {
                    king.IsInCheck = false;
                    king.UnCheck();
                }
            }
        }
    }
}