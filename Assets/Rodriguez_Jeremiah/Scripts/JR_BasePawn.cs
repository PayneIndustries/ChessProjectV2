﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasePawn : MonoBehaviour
{
    /*        
//        Developer Name: Jeremiah Rodriguez
//         Contribution: Created the BasePawn to build off of every other pawn.
//         Feature : Created to run the base movement of the pieces. This script handles Highlight.
//         Start & End dates : 10/28/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA

//              
//                        
//*/

	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: I only added in a public variable that places each piece where it needs to be on the board, and I
	//     	created the "movementUnhightlight" method that unhiglights each tile after a piece moves.
	//     	Feature : Tile Unhighlight.
	//     	Start & End dates : 10/05/17 - 11/10/17
	//            	References: No references were used
	//                    	Links: NA

    public GameObject Controller;
    public GameObject currentPawn;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private GameObject targetedSquare;
    private JR_TilePositionScript movementCheck;
    public JR_BasePawn thisPawnScript;

    [SerializeField]public Vector3 startPosition;
    private ZM_BoardManager board;
    public GameObject BoardManager;
    public bool isWhite;
    protected TurnSwap turnSwap;
    private HighlightScript setColor;
    public bool inCheck;
    public AudioClip movement;
    public AudioClip eat;
    public AudioSource audio;
    public GameObject audioManager;
    public int caseSet;

    // Use this for initialization

    public void Awake()
    {
       turnSwap = Controller.GetComponent<TurnSwap>();
    }
    public void Start()
    {
        if (turnSwap.wasInstantiated != true)
        {
            currentPawn.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }

        if(turnSwap.wasInstantiated == true)
        {
            if (this.isWhite)
            {
                turnSwap.whitePieces.Add(this.gameObject);
            }

            else
            {
                turnSwap.blackPieces.Add(this.gameObject);
            }
        }
        currentPosition = currentPawn.transform.position;
        newPosition = currentPosition;
        board = BoardManager.GetComponent<ZM_BoardManager>();
        turnSwap = Controller.GetComponent<TurnSwap>();
        setColor = currentPawn.GetComponent<HighlightScript>();
        thisPawnScript = this.GetComponent<JR_BasePawn>();
        audio = this.GetComponent<AudioSource>();
        caseSet = 0;

        if (isWhite)
        {
            setColor.TeamColor = Color.white;
        }
        else
        {
            setColor.TeamColor = Color.black;
        }
    }

    public void Update()
    {
        if (currentPawn.tag == "Pawn")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                currentPawn.GetComponent<JR_BasePawn>().movementUnhiglight();
            }
        }
    }
    
    public void FixedUpdate() {

    }

    public void PositionToMove()
    {
        if (inCheck)
        {
            print("You are in check!, You must move your king!!!");
        }
        else
        {
            if (currentPawn.tag == "Selected")
            {
                if (board.SelectedTile() != null && board.SelectedTile().tag != "Occupied")
                {
                    targetedSquare = board.SelectedTile();
                    newPosition = new Vector3(targetedSquare.transform.position.x, currentPawn.transform.position.y, targetedSquare.transform.position.z);
                    MovedPosition();
                    audio.clip = movement;
                    audio.Play();

                }

                else if (board.SelectedTile() == null)
                {
                    Debug.Log("Object instance 'board' not set");
                }
            }
        }
    }

    public void MovedPosition()
    {
        if (currentPosition != newPosition)
        {
            currentPosition = newPosition;

            currentPawn.transform.position = newPosition;

            targetedSquare = null;

            turnSwap.curPlayerWhite = !turnSwap.curPlayerWhite;

            turnSwap.SwapTurn();

            board.SelectedTileToNull();
            
        }
    }

    public Vector3 GetLocationOfPawn()
    {
        return currentPosition;
    }

    public GameObject Board()
    {
        return BoardManager;
    }

    public void movementUnhiglight()
    {
        foreach (GameObject tile in board.Tiles)
        {
            if (tile.transform.position.z % 2 != 0 && tile.transform.position.x % 2 != 0 || tile.transform.position.z % 2 == 0 && tile.transform.position.x % 2 == 0)
            {
                tile.GetComponent<Renderer>().material.color = board.brown;
                tile.GetComponent<JR_TilePositionScript>().validMove = false;
            }
            else
            {
                tile.GetComponent<Renderer>().material.color = board.lightB;
                tile.GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }

    private void OnDestroy()
    {
        audioManager = GameObject.Find("WorldAudio");
        audioManager.GetComponent<JR_DestroySound>().PlayAudio();
        if (isWhite)
        {
            //remove from white array
            turnSwap.whitePieces.Remove(currentPawn);
        } else
        {
            //remove from black array
            turnSwap.blackPieces.Remove(currentPawn);
        }
    }


    public void Instantiate()
    {
        Controller = GameObject.Find("ControlManagerScript");
        BoardManager = GameObject.Find("BoardControl");
    }
}
    //Edited by Zaryn Magtibay