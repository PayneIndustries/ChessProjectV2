﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Pawn : JR_BasePawn {

    GameObject GameBoard;
    private ZM_BoardManager Holder;
    private bool isFirstMove;
    GameObject pawnInZone;
    JR_BasePawn basePawn;
    public GameObject thisPawn;
    private GameObject enemyCheck;
    private int moveableActions;
    private Color checkColorIdenity;
    private HighlightScript highlight;
    private bool canDestroyPawn = false;



    private new void Start()
    {
        base.Start();
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
        isFirstMove = true;
        highlight = thisPawn.GetComponent<HighlightScript>();


        if (isFirstMove)
        {
            moveableActions = 2;
        }
    }

    private new void Update()
    {
        base.Update();
        if (thisPawn.tag == "Selected")
        {

            if (highlight.IsSelected())
            {
                pawnMovementHighlight();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                CheckIfValid();
            }
        }

        else
        {
            movementUnhiglight();
        }
    }

    public void CheckIfValid()
    {
        if (isWhite)
        {
            if (isFirstMove && moveableActions == 2)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 2 && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    // thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                    //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();

                }

            } else
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }
                else
                {
                    MoveAndDestroy();
                }
            }


        }

        //IF the Pawn is Black
        else
        {
            if (isFirstMove && moveableActions == 2)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 2)
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                }


            }
            else if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                }

                else
                {
                    MoveAndDestroy();
                }
            }
        }       
    }

    public void MoveAndDestroy()
    {
        if (moveableActions != 0)
        {
            if (isWhite)
            {
                if (CanDestroy() && Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() != isWhite)
                {
                    Destroy(Holder.WHOISTHERE());
                    Holder.SelectedTile().tag = "tile";
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                    canDestroyPawn = false;
                }
            }

            else
            {
                Debug.Log(Holder.SelectedTile().tag);
                Debug.Log(Holder.WhoIsThere2());
                if (CanDestroy() && Holder.SelectedTile().tag == "Occupied" && Holder.WhoIsThere2() == Holder.BlackCheckSetTrue())
                {
                    Destroy(Holder.WHOISTHERE());
                    Holder.SelectedTile().tag = "tile";
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                    canDestroyPawn = false;
                    Holder.BlackCheckSetFalse();
                }

                else
                {
                    Debug.Log(" That was not a legal move.");
                }
            }
        }
    }

    public void PawnReset()
    {
        moveableActions = 1;
        isFirstMove = false;
    }

    void pawnMovementHighlight()
    {
        foreach (GameObject tile in Holder.Tiles)
        {
            if (isFirstMove)
            {
                if (tile.transform.position.z == thisPawn.transform.position.z + 1 && tile.transform.position.x == thisPawn.transform.position.x && tile.tag != "Occupied")
                {
                    tile.GetComponent<Renderer>().material.color = Color.yellow;
                }
                else if (tile.transform.position.z == thisPawn.transform.position.z + 2 && tile.transform.position.x == thisPawn.transform.position.x && tile.tag != "Occupied")
                {
                    tile.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
            else if (!isFirstMove)
            {
                if (tile.transform.position.z == thisPawn.transform.position.z + 1 && tile.transform.position.x == thisPawn.transform.position.x && tile.tag != "Occupied")
                {
                    tile.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }

    public bool CanDestroy()
    {
        //if (thisPawn.transform.position.x - 1 < 0 || thisPawn.transform.position.z - 1 < 0 || thisPawn.transform.position.x + 1 > 7 || thisPawn.transform.position.z + 1 > 7)
            //return false;

        if (isWhite)
        { 
            if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x + 1 && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1)
            {
                canDestroyPawn = true;
            }
            else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x - 1 && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1)
            {
                canDestroyPawn = true;
            }
        }

        else
        {
            if(Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x - 1 && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
            {
                canDestroyPawn = true;
                Debug.Log("Am I being called?");
            }
            else if(Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x + 1 && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
            {
                canDestroyPawn = true;
                Debug.Log("Am I being called?");
            }
        }
        return canDestroyPawn;
    }
}



