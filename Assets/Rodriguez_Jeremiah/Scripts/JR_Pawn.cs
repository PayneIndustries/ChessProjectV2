using System.Collections;
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
        if(basePawn != null)
        {

        }
        if(thisPawn.tag == "Selected")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                CheckIfValid();
                Debug.Log("Am I being called");
            }
        }

        else
        {
            thisPawn.layer = LayerMask.NameToLayer("Default");
        }
    }

    public void CheckIfValid()
    {
        if (isWhite)
        {
            if (isFirstMove && moveableActions == 2)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 2)
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1)
                {
                    moveableActions = 0;
                    PositionToMove();


                }

            }
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                }
            }

            else
            {
                MoveAndDestroy();
            }

        }

        //IF the Pawn is Black
        else
        {
            if (isFirstMove && moveableActions == 2)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 2)
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                }


            }
            else if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                }
            }

            else
            {
                MoveAndDestroy();
            }
        }
        
    }

    public void MoveAndDestroy()
    {
        if (moveableActions > 0)
        {
            if (isWhite)
            {
                if (thisPawn.transform.position.x + 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z + 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else if (thisPawn.transform.position.x - 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z + 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else
                {
                    Debug.Log("That was not a legal move.");
                }
            }

            else
            {
                if (thisPawn.transform.position.x - 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z - 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else if (thisPawn.transform.position.x - 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z - 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else
                {
                    Debug.Log("That was not a legal move.");
                }
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        enemyCheck = collision.gameObject;
        checkColorIdenity = enemyCheck.GetComponent<Renderer>().material.color;
        if(collision.gameObject.tag == "pawn" && checkColorIdenity != this.GetComponent<Renderer>().material.color && checkColorIdenity != highlight.TeamColor)
        {
            Destroy(enemyCheck);
        }
    }

    public void PawnReset()
    {
        moveableActions = 1;
        isFirstMove = false;
    }
}


