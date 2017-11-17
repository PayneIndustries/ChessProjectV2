using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Rook : JR_BasePawn {


    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I worked with Zaryn on the development of this script. She had more of a hand on it than I did.
    //         Feature : This is for the Rook movement as well as managing the rules for what the Rook can do.
    //         Start & End dates : 11/07/17 - 11/10/17 
    //                References: No references were used
    //                        Links: NA


	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: I worked on the logic of the rooks movement. I also implemented its respective tile path highlight.
	//     	Feature : Rook movement and tile highlight.
	//     	Start & End dates : 11/07/17 - 11/10/17
	//            	References: No references were used
	//                    	Links: NA



    GameObject GameBoard;
    private ZM_BoardManager Holder;

    JR_BasePawn basePawn;
    public GameObject thisPawn;

    private int moveableActions;
    private Vector3 tileThatPawnIsOn;
    private bool isvalidMove;

    private new void Start()
    {

        base.Start();
        basePawn = thisPawnScript;
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
        isvalidMove = false;

    }

    private new void Update()
    {
        base.Update();
        
    }

    private new void FixedUpdate() {
        if (thisPawn.tag == "Selected")
        {
            //tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            thisPawn.GetComponent<JR_Rook>().rookMovementHighlight();
            if (Input.GetButtonDown("Fire1"))
            {
                if(Holder.SelectedTile().transform.position.x != this.transform.position.x  && Holder.SelectedTile().transform.position.z != this.transform.position.z)
                {
                    isvalidMove = false;
                }
                else
                {
                    isvalidMove = true;
                }
                //checkMovement();
                newCheckMovement();
                movementUnhiglight();
                //rookMovementUnhiglight();
            }
        }
    }
    /*
    void checkMovement() {
        if (Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied" || Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().tag != "Occupied") {
            
        }
    }
    */

    void rookMovementHighlight() {
        /*
        foreach (GameObject tile in Holder.Tiles)
        {
            if (tile.transform.position.z == thisPawn.transform.position.z && tile.transform.position != tileThatPawnIsOn && tile.tag != "Occupied" || tile.transform.position.x == thisPawn.transform.position.x && tile.transform.position != tileThatPawnIsOn && tile.tag != "Occupied")
            {
                tile.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        */
        horizontalUpMovement();
        horizontalDownMovement();
        verticalUpMovement();
        verticalDownMovement();
    }

    void newCheckMovement() {
        if (Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true && Holder.SelectedTile().tag != "Occupied" && isvalidMove) {
            PositionToMove();
           // movementUnhiglight();
        }

        else if (isWhite)
        {
            if (Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() != isWhite && isvalidMove)
            {
                Destroy(Holder.WHOISTHERE());
                Holder.SelectedTile().tag = "tile";
                PositionToMove();
                //movementUnhiglight();
            }

            
        }

        else
        {
            if(Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() == Holder.BlackCheckSetTrue() && isvalidMove)
            {
                Destroy(Holder.WHOISTHERE());
                Holder.SelectedTile().tag = "tile";
                PositionToMove();
               // movementUnhiglight();
                Holder.BlackCheckSetFalse();
            }
        }
    }

    void horizontalUpMovement() {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x++;
            if (x >= 8 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void horizontalDownMovement() {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x--;
            if (x < 0 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void verticalUpMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            z++;
            if (z >= 8 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void verticalDownMovement() {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            z--;
            if (z < 0 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }
}


