﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Bishop : JR_BasePawn {

    /*        
//         Developer Name: Jeremiah Rodriguez
//         Contribution: I worked with Zaryn on creating this script as well as getting functionality to it.
//         Feature : The bishop is a pawn that needs to be used for chess that has the ability to move in diagonal directions on color.
//         Start & End dates : 11/08/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA

//              
//                        
//*/

	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: I helped create the logic in the Bishops movement, and I also created it's tile highlight.
	//     	Feature : Bishop movement and its tile highlight.
	//     	Start & End dates : 11/07/17 - 11/10/17
	//            	References: No references were used
	//                    	Links: NA


    GameObject GameBoard;
    public GameObject thisPawn;

    private ZM_BoardManager Holder;
    JR_BasePawn basePawn;


    private int moveableActions;
    private Vector3 tileThatPawnIsOn;
    int x, z;
    private List<GameObject> MoveableTiles;
    private bool isValidMove;

    private new void Start()
    {
            base.Start();
        basePawn = thisPawnScript;
        GameBoard = Board();
            Holder = Board().GetComponent<ZM_BoardManager>();
        isValidMove = false;
    }

    private new void FixedUpdate()
    {
        if (thisPawn.tag == "Selected")
        {
            // tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            thisPawn.GetComponent<JR_Bishop>().bishopMovementHighlight();

            if (Input.GetButtonDown("Fire1"))
            {
                checkMovement();
                movementUnhiglight();
            }

            //if(Holder.SelectedTile())
        }
    }

    void checkMovement()
    {
        if (Holder.SelectedTile().tag != "Occupied" && Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true)
        {
            PositionToMove();
           // MoveableTiles.Clear();
            // movementUnhiglight();
        }


        else if (isWhite && Holder.WHOISTHERE() != null)
        {
            {
                if (Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() != isWhite)
                {
                    Destroy(Holder.WHOISTHERE());
                    Holder.SelectedTile().tag = "tile";
                    PositionToMove();
                    //movementUnhiglight();
                }


            }
        }

        else if (!isWhite && Holder.WHOISTHERE() != null)
        {
            if (Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() == Holder.BlackCheckSetTrue())
            {
                Destroy(Holder.WHOISTHERE());
                Holder.SelectedTile().tag = "tile";
                PositionToMove();
                // movementUnhiglight();
                Holder.BlackCheckSetFalse();
            }

        }
    }

    void bishopMovementHighlight()
    {
        checkUL();
        checkUR();
        checkLL();
        checkLR();
    }

    void checkUL()
    {
        //checks upper left diagonal
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x--;
            z++;
            if (x < 0 || z >= 8 || Holder.Tiles[x, z].tag == "Occupied" )
            {
               /* if (Holder.WHOISTHERE() != null)
                {
                    if (this.isWhite && Holder.WhoIsThere2() != isWhite)
                    {
                        Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                    }
                    else if (this.isWhite != true && Holder.BlackCheckSetTrue())
                    {
                        Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                    }
                }*/
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;

            }
        }
    }

    void checkUR()
    {
        // checks upper right diagonal
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x++;
            z++;
            if (x >= 8 || z >= 8 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;

            }
        }
    }

    void checkLL()
    {
        // checks lower left diagonal
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x--;
            z--;
            if (x < 0 || z < 0 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }

    void checkLR()
    {
        // checks lower right diagonal
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x++;
            z--;
            if (x >= 8 || z < 0 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;

            }
        }
    }
}

