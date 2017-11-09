using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Rook : JR_BasePawn {

    GameObject GameBoard;
    private ZM_BoardManager Holder;

    JR_BasePawn basePawn;
    public GameObject thisPawn;

    private int moveableActions;
    private Vector3 tileThatPawnIsOn;

    private new void Start()
    {
        base.Start();
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
    }

    private new void Update()
    {
        base.Update();
        
    }

    private new void FixedUpdate() {
        if (thisPawn.tag == "Selected")
        {
            tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            rookMovementHighlight();
            if (Input.GetButtonDown("Fire1"))
            {
                //checkMovement();
                newCheckMovement();
                //rookMovementUnhiglight();
            }
        }
        else
        {
            movementUnhiglight();
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
        if (Holder.SelectedTile().GetComponent<JR_TilePositionScript>().validMove == true && Holder.SelectedTile().tag != "Occupied") {
            PositionToMove();
            movementUnhiglight();
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
