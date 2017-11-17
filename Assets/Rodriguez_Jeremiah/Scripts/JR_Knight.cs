using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Knight : JR_BasePawn {

    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I assisted Zaryn in the creation and development of this script. Alex Dangler Assisted with creation of Knight 
    //         Feature : The knight pawn as well as its movement for the game.
    //         Start & End dates : 11/09/17 - 11/10/17 
    //                References: No references were used
    //                        Links: NA



	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: With the help of Jeremiah and Alex Dangler, I worked on the logic of the knights movement. I also implemented its respective tile path highlight.
	//     	Feature : Knight movement and tile highlight.
	//     	Start & End dates : 11/09/17 - 11/10/17
	//            	References: No references were used
	//       


    GameObject GameBoard;
    public GameObject thisPawn;

    private ZM_BoardManager Holder;
    JR_BasePawn basePawn;


    private int moveableActions;
    private Vector3 tileThatPawnIsOn;
    int x, z;


    private new void Start()
    {
            base.Start();
        basePawn = thisPawnScript;
        GameBoard = Board();
            Holder = Board().GetComponent<ZM_BoardManager>();

    }

    private new void FixedUpdate()
    {
        if (thisPawn.tag == "Selected")
        {
           // tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            thisPawn.GetComponent<JR_Knight>().knightMovementHighlight();

            if (Input.GetButtonDown("Fire1"))
            {
                checkMovement();
                movementUnhiglight();
            }
        }
    }

    void checkMovement()
    {
        if (Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true && Holder.SelectedTile().tag != "Occupied")
        {
            PositionToMove();
           // movementUnhiglight();
        }
        else if (isWhite)
        {
            if (Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() != isWhite && Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true)
            {
                Destroy(Holder.WHOISTHERE());
                Holder.SelectedTile().tag = "tile";
                PositionToMove();
               // movementUnhiglight();
            }


        }

        else
        {
            if (Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() == Holder.BlackCheckSetTrue() && Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true)
            {
                Destroy(Holder.WHOISTHERE());
                Holder.SelectedTile().tag = "tile";
                PositionToMove();
               // movementUnhiglight();
                Holder.BlackCheckSetFalse();
            }
        }
    }

    void knightMovementHighlight()
    {
        checkUL();
        checkUR();
        checkRU();
        checkRD();
        checkDL();
        checkDR();
        checkLU();
        checkLD();
    }
   
    void checkUL()
    {
        //up then left "L"
        int x = (int)thisPawn.transform.position.x - 1;
        int z = (int)thisPawn.transform.position.z + 2;
        if(x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkUR()
    {
        //up then right "L"
        int x = (int)thisPawn.transform.position.x + 1;
        int z = (int)thisPawn.transform.position.z + 2;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkRU()
    {
        //right then up "L"
        int x = (int)thisPawn.transform.position.x + 2;
        int z = (int)thisPawn.transform.position.z + 1;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkRD()
    {
        //right then down "L"
        int x = (int)thisPawn.transform.position.x + 2;
        int z = (int)thisPawn.transform.position.z - 1;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkDL()
    {
        //down then left "L"
        int x = (int)thisPawn.transform.position.x - 1;
        int z = (int)thisPawn.transform.position.z - 2;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkDR()
    {
        //down then right "L"
        int x = (int)thisPawn.transform.position.x + 1;
        int z = (int)thisPawn.transform.position.z - 2;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkLU()
    {
        //left then up "L"
        int x = (int)thisPawn.transform.position.x - 2;
        int z = (int)thisPawn.transform.position.z + 1;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }

    void checkLD()
    {
        //left then down "L"
        int x = (int)thisPawn.transform.position.x - 2;
        int z = (int)thisPawn.transform.position.z - 1;
        if (x >= 0 && x < 8 && z >= 0 && z < 8 && Holder.SelectedTile().tag != "Occupied")
        {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
        }
    }
}

