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
        if (Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied" || Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().tag != "Occupied")
        {
            PositionToMove();
            movementUnhiglight();
        }
    }

    void queenMovementHighlight()
    {
        foreach (GameObject tile in Holder.Tiles)
        {
            if (tile.transform.position.z == thisPawn.transform.position.z && tile.transform.position != tileThatPawnIsOn && tile.tag != "Occupied" || tile.transform.position.x == thisPawn.transform.position.x && tile.transform.position != tileThatPawnIsOn && tile.tag != "Occupied")
            {
                tile.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        checkUL();
        checkUR();
        checkLL();
        checkLR();
    }
    //HAVE TO ADD IN CHECK FOR OCCUPPIED TILES
    void checkUL()
    {
        //checks upper left diagonal
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        while (true)
        {
            x--;
            z++;
            if (x < 0 || z >= 8)
            {
                break;
            }
            else
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
            if (x >= 8 || z >= 8)
            {
                break;
            }
            else
            {
            Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
            if (x < 0 || z < 0)
            {
                break;
            }
            else
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
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
            if (x >= 8 || z < 0)
            {
                break;
            }
            else
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }
}

