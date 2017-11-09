using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Bishop : JR_BasePawn {

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

    private new void FixedUpdate()
    {
        if (thisPawn.tag == "Selected")
        {
            tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            bishopMovementHighlight();

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
            if (x < 0 || z >= 8 || Holder.Tiles[x, z].tag == "Occupied")
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

