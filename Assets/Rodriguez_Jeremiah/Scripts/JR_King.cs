using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_King : JR_BasePawn {

    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I wrote the script. This scipt is null, I remade it and named it JR_KingPawn.
    //         Feature : The bishop is a pawn that needs to be used for chess that has the ability to move in diagonal directions on color.
    //         Start & End dates : 10/28/17 - 11/10/17

	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: I helped create the logic in the Kings movement, and I also created it's tile highlight.
	//     	Feature : King movement and its tile highlight.
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

    public new void Start()
    { 
        base.Start();
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
    }

    private new void FixedUpdate()
    {
        if (thisPawn.tag == "Selected")
        {
            kingMovementHighlight();

            if (Input.GetButtonDown("Fire1"))
            {
                checkMovement();
            }
        }
        else
        {
            //movementUnhiglight();
        }
    }

    void checkMovement()
    {
        if (Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true)
        {
            PositionToMove();
            //movementUnhiglight();
        }
    }

    void kingMovementHighlight()
    {
        horizontalLeftMovement();
        horizontalRightMovement();
        verticalUpMovement();
        verticalDownMovement();
        checkUL();
        checkUR();
        checkLL();
        checkLR();
    }

    void horizontalRightMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        if (x >= 0 && x < 8)
        {
            x = x + 1;


            if (Holder.Tiles[x, z].tag != "Occupied" && x < 8)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
        else
        {
            x = (int)thisPawn.transform.position.x;
        }
    }

    void horizontalLeftMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        if (x >= 0 && x < 8)
        {
            x = x - 1;

            if (Holder.Tiles[x, z].tag != "Occupied" && x >= 0)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
        else
        {
            x = (int)thisPawn.transform.position.x;
        }
    }

    void verticalUpMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (z >= 0 && z < 8)
        {
            z = z + 1;


            if (Holder.Tiles[x, z].tag != "Occupied" && z < 8)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
        else
        {
            z = (int)thisPawn.transform.position.z;
        }
    }

    void verticalDownMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (z >= 0 && z < 8)
        {
            z = z - 1;


            if (Holder.Tiles[x, z].tag != "Occupied" && z >= 0)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
        else
        {
            z = (int)thisPawn.transform.position.z;
        }
    }

    void checkUL()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x - 1;
            z = z - 1;

            if (x >= 0 || z < 8)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                    Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                }
            }
        }

        else
        {
            x = (int)thisPawn.transform.position.x;
            z = (int)thisPawn.transform.position.z;
        }
    }

    void checkUR()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x + 1;
            z = z + 1;

            if (x < 8 || z < 8)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                    Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                }
            }
        }

        else
        {
            x = (int)thisPawn.transform.position.x;
            z = (int)thisPawn.transform.position.z;
        }
    }
    void checkLL()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x - 1;
            z = x - 1;

            if (x >= 0 || z >= 0)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                    Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                }
            }
        }

        else
        {
            x = (int)thisPawn.transform.position.x;
            z = (int)thisPawn.transform.position.z;
        }
    }

    void checkLR()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x + 1;
            z = z - 1;

            if (x < 8 || z >= 0)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                    Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                }
            }
        }

        else
        {
            x = (int)thisPawn.transform.position.x;
            z = (int)thisPawn.transform.position.z;
        }
    }
}
