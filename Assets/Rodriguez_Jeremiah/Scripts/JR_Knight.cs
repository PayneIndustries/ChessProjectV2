using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Knight : JR_BasePawn {

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

