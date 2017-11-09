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
<<<<<<< HEAD
    private Color checkColorIdenity;
    private HighlightScript highlight;
    
=======

>>>>>>> ZarynBranch


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
<<<<<<< HEAD
=======
            pawnMovementHighlight();
            trigger.layer = LayerMask.NameToLayer("Ignore Raycast");
>>>>>>> ZarynBranch
            if (Input.GetButtonDown("Fire1"))
            {
                CheckIfValid();
                Debug.Log("Am I being called");
            }
        }

        else
        {
            movementUnhiglight();
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

            }
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                    //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
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
                    // thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                    // thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }


            }
            else if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x  && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1)
                {
                    moveableActions = 0;
                    PositionToMove();
                    //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }
            }

            else
            {
                MoveAndDestroy();
            }
        }
<<<<<<< HEAD
        
=======
        movementUnhiglight();
>>>>>>> ZarynBranch
    }

    public void MoveAndDestroy()
    {
        if (moveableActions != 0)
        {
            if (isWhite)
            {
               if (thisPawn.transform.position.x + 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z + 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }

                else if (thisPawn.transform.position.x - 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z + 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                     //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
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
                    //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
                }

                else if (thisPawn.transform.position.x - 1 == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z - 1 == Holder.SelectedTile().transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    // thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
                    highlight.StopHighlight();
                    PawnReset();
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
        checkColorIdenity = enemyCheck.GetComponentInChildren<Renderer>().material.color;
        if(collision.gameObject.tag == "pawn" && checkColorIdenity != this.GetComponentInChildren<Renderer>().material.color && checkColorIdenity != highlight.TeamColor)
        {
            Destroy(enemyCheck);
            //thisPawn.GetComponent<Renderer>().material.color = highlight.TeamColor;
            highlight.StopHighlight();
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
            if (isFirstMove) {
                if (tile.transform.position.z == thisPawn.transform.position.z + 1 && tile.transform.position.x == thisPawn.transform.position.x && tile.tag != "Occupied")
                {
                    tile.GetComponent<Renderer>().material.color = Color.yellow;
                } else if (tile.transform.position.z == thisPawn.transform.position.z + 2 && tile.transform.position.x == thisPawn.transform.position.x && tile.tag != "Occupied") {
                    tile.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
            else {
                if (tile.transform.position.z == thisPawn.transform.position.z + 1 && tile.transform.position.x == thisPawn.transform.position.x && tile.tag != "Occupied")
                {
                    tile.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }
}


