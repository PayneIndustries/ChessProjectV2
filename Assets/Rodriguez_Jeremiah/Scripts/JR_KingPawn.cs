using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JR_KingPawn : JR_BasePawn
{
    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I wrote the script. This script handles the king base functionality.
    //         Feature : The King pawn for the chess board as well as Check().
    //         Start & End dates : 11/08/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA


	//     	Developer Name: Zaryn Magtibay
	//     	Contribution: I helped create the logic in the Kings movement, and I also created it's tile highlight.
	//     	Feature : King movement and its tile highlight.
	//     	Start & End dates : 11/07/17 - 11/10/17
	//            	References: No references were used
	//                    	Links: NA

    GameObject GameBoard;
    private ZM_BoardManager Holder;
    public GameObject thisPawn;
    private int moveableActions;
    private HighlightScript highlight;
    private bool canDestroyPawn = false;
    public bool IsInCheck;



    private new void Start()
    {
        base.Start();
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
        highlight = thisPawn.GetComponent<HighlightScript>();
        moveableActions = 1;

    }

    private new void Update()
    {
        base.Update();
        if (IsInCheck)
        {
            Check();
        }
        if (thisPawn.tag == "Selected")
        {

            if (Input.GetButtonDown("Fire1"))
            {
                CheckIfValid();
            }
        }

        else
        {
            //movementUnhiglight();
        }
    }

    public void CheckIfValid()
    {   //IF the Pawn is white
        if (isWhite)
        {
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
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

        else
        {
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
                {
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag != "Occupied")
                {

                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag != "Occupied")
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
                if (CanDestroy() && Holder.WhoIsThere2() != isWhite)
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
                if (CanDestroy() && Holder.JustForKing() == true)
                {
                    Destroy(Holder.WHOISTHERE());
                    Holder.SelectedTile().tag = "tile";
                    moveableActions = 0;
                    PositionToMove();
                    highlight.StopHighlight();
                    PawnReset();
                    canDestroyPawn = false;
                    Holder.JustForKingFalse();
                }
            }
        }
    }


    public void PawnReset()
    {
        moveableActions = 1;
    }


    public bool CanDestroy()
    {
        //if (thisPawn.transform.position.x - 1 < 0 || thisPawn.transform.position.z - 1 < 0 || thisPawn.transform.position.x + 1 > 7 || thisPawn.transform.position.z + 1 > 7)
        // return false;

        if (isWhite)
        {
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }
                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

            }
        }


        else
        {
            if (moveableActions == 1)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

                else if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;

                }

                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;

                }
                else if (Holder.SelectedTile().transform.position.x + 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;

                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z - 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }
                else if (Holder.SelectedTile().transform.position.x - 1 == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 1 && Holder.SelectedTile().tag == "Occupied")
                {
                    canDestroyPawn = true;
                }

            }

        }

        return canDestroyPawn;

    }

   public void Check()
    {
        if (IsInCheck)
        {
            JR_BasePawn disabledPiece;
            if (this.isWhite)
            {
                foreach (GameObject i in turnSwap.whitePieces)
                {
                    if (GameObject.Find("King"))
                    {
                        print("You are in check!");
                    }
                    else
                    {
                        disabledPiece = gameObject.GetComponent<JR_BasePawn>();
                        disabledPiece.inCheck = true;
                    }
                }
            }

            else
            {
                
                if (this.isWhite != true)
                {
                    JR_BasePawn disabledPieceBlack;
                    foreach (GameObject i in turnSwap.whitePieces)
                    {
                        if (GameObject.Find("King"))
                        {
                            print("You are in check!");
                        }
                        else
                        {
                            disabledPieceBlack = gameObject.GetComponent<JR_BasePawn>();
                            disabledPieceBlack.inCheck = true;
                        }
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (isWhite)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(7);
        }
    }

   public void UnCheck()
    {
        if (!IsInCheck)
        {
            JR_BasePawn disabledPiece;
            if (this.isWhite)
            {
                foreach (GameObject i in turnSwap.whitePieces)
                {
                    if (GameObject.Find("King"))
                    {
                        print("You are in check!");
                    }
                    else
                    {
                        disabledPiece = gameObject.GetComponent<JR_BasePawn>();
                        disabledPiece.inCheck = true;
                    }
                }
            }

            else
            {

                if (this.isWhite != true)
                {
                    JR_BasePawn disabledPieceBlack;
                    foreach (GameObject i in turnSwap.whitePieces)
                    {
                        if (GameObject.Find("King"))
                        {
                            print("You are in check!");
                        }
                        else
                        {
                            disabledPieceBlack = gameObject.GetComponent<JR_BasePawn>();
                            disabledPieceBlack.inCheck = true;
                        }
                    }
                }
            }
        }
    }
}

