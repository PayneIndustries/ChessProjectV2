using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Queen : JR_BasePawn {

    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I worked with Zaryn for the Development and creation of the Queen Script.
    //         Feature : This script is designed for the queen and encompasses movement of the queen as well as her other actions.
    //         Start & End dates : 11/08/17 - 11/10/17 
    //                References: No references were used
    //                        Links: NA





	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: I worked on the logic of the Queens movement. I also implemented its respective tile path highlight.
	//     	Feature : Queen movement and tile highlight.
	//     	Start & End dates : 11/07/17 - 11/10/17
	//            	References: No references were used
	//      	              Links: NA


    GameObject GameBoard;
    public GameObject thisPawn;

    private ZM_BoardManager Holder;
    public JR_BasePawn basePawn;
    

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

    private new void FixedUpdate() {
        if (thisPawn.tag == "Selected")
        {
            //tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            queenMovementHighlight();
            
            if (Input.GetButtonDown("Fire1"))
            {
                checkMovement();
            }
        }
        else
        {
           // movementUnhiglight();
        }
    }

    void checkMovement()
    { 
        if (Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true && Holder.SelectedTile().tag != "Occupied")
        {
            PositionToMove();
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

    void queenMovementHighlight()
    {
        horizontalUpMovement();
        horizontalDownMovement();
        verticalUpMovement();
        verticalDownMovement(); 
        checkUL();
        checkUR();
        checkLL();
        checkLR();
    }

    void horizontalUpMovement()
    {
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
               // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void horizontalDownMovement()
    {
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
               // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
               // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void verticalDownMovement()
    {
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
              //  Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
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
            if (x < 0 || z >= 8 || Holder.Tiles[x, z].tag == "Occupied")
            {
                break;
            }
            else if (Holder.Tiles[x, z].tag != "Occupied")
            {
               // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied") {
                    break;
                }
            }
        }
    }

    void checkUR() {
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
            else if (Holder.Tiles[x,z].tag != "Occupied")
            {
           // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void checkLL() {
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
               // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
                if (Holder.Tiles[x, z].tag == "Occupied")
                {
                    break;
                }
            }
        }
    }

    void checkLR() {
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
               // Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }
}

