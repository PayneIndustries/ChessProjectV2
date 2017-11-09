using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Queen : JR_BasePawn {

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
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
    }

    private new void FixedUpdate() {
        if (thisPawn.tag == "Selected")
        {
            tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            queenMovementHighlight();
            
            if (Input.GetButtonDown("Fire1"))
            {
                checkMovement();
            }
        }
        else
        {
            movementUnhiglight();
        }
    }

    void checkMovement()
    { 
        if (Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true && Holder.SelectedTile().tag != "Occupied")
        {
            PositionToMove();
            movementUnhiglight();
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
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }
}

