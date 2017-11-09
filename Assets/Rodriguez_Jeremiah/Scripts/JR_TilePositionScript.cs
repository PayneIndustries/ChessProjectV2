﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_TilePositionScript : MonoBehaviour {

    public GameObject thisTile;
    private Vector3 tilePosition;
    private bool pawnHere;
    private ZM_BoardManager boardManager;
    private GameObject whoIsHere;
    public bool validMove;



    // Use this for initialization
    void Start () {

        tilePosition = new Vector3(thisTile.transform.position.x, thisTile.transform.position.y, thisTile.transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public Vector3 TilePosition()
    {
        return tilePosition;
    }

    public bool pawnThere()
    {
        return pawnHere;
    }

    private void OnTriggerStay(Collider other)
    {
       if(other.tag == "Selected" || other.tag == "Pawn")
        {
            pawnHere = true;
            Occupied();
            whoIsHere = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pawn" || other.tag == "Selected")
        {
            pawnHere = false;
            Occupied();
            whoIsHere = null;
        }

        else
        {
            Debug.Log("The object that left me is not tagged!");
        }
    }

    private void Occupied()
    {
        if (pawnHere)
        {
            thisTile.tag = "Occupied";
        }

        else
        {
            thisTile.tag = "tile";
        }
    }

    public GameObject WhoIsHere()
    {
        return whoIsHere;
    }
    
}

/*        
//        Developer Name: Jeremiah Rodriguez
//         Contribution: Runs the positions of the tiles. Sends info to main control.
//                Feature : Created the tile script that indicates the position of the tile.
//                Start & End dates : 10/30/17 - Current
//                References:
//                        Links:
//*/
