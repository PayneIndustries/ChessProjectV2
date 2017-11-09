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
        if (thisPawn.tag == "Selected")
        {
            tileThatPawnIsOn = Holder.whatTileIsPawnOn(thisPawn).transform.position;
            rookMovementHighlight();
            if (Input.GetButtonDown("Fire1"))
            {
                checkMovement();
                //rookMovementUnhiglight();
            }
        }
        else
        {
            movementUnhiglight();
        }
    }

    void checkMovement() {
        if (Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied" || Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().tag != "Occupied") {
            PositionToMove();
            movementUnhiglight();
        }
    }

    void rookMovementHighlight() {
        foreach (GameObject tile in Holder.Tiles)
        {
            if (tile.transform.position.z == thisPawn.transform.position.z && tile.transform.position != tileThatPawnIsOn && tile.tag != "Occupied" || tile.transform.position.x == thisPawn.transform.position.x && tile.transform.position != tileThatPawnIsOn && tile.tag != "Occupied")
            {
                tile.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }
}
