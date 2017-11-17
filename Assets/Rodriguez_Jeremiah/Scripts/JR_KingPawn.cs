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
        if (thisPawn.tag == "Selected")
        {
            //thisPawn.GetComponent<JR_KingPawn>().kingMovementHighlight();
            if (Input.GetButtonDown("Fire1"))
            {
                CheckIfValid();
                movementUnhiglight();
            }
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
            Debug.Log("Am I being Called?");
            JR_BasePawn disabledPiece;
            if (this.isWhite)
            {
                foreach (GameObject i in turnSwap.whitePieces)
                {
                    if (i == GameObject.Find("King"))
                    {
                        print("You are in check!");
                    }
                    else
                    {
                        disabledPiece = i.GetComponent<JR_BasePawn>();
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
                        if (i == GameObject.Find("King"))
                        {
                            print("You are in check!");
                        }
                        else
                        {
                            disabledPieceBlack = i.GetComponent<JR_BasePawn>();
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
        Debug.Log("Have I been called?");
        if (!IsInCheck)
        {
            JR_BasePawn disabledPiece;
            if (this.isWhite)
            {
                foreach (GameObject i in turnSwap.whitePieces)
                {
                    if (i == GameObject.Find("King"))
                    {
                        print("You are no longer in check!");
                    }
                    else
                    {
                        disabledPiece = i.GetComponent<JR_BasePawn>();
                        disabledPiece.inCheck = false;
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
                        if (i == GameObject.Find("King"))
                        {
                            print("You are no longer in check!");
                        }
                        else
                        {
                            disabledPieceBlack = i.GetComponent<JR_BasePawn>();
                            disabledPieceBlack.inCheck = false;
                        }
                    }
                }
            }
        }
    }
    //Movement Highlight
  /*  void kingMovementHighlight()
    {
        horizontalLeftMovement();
        horizontalRightMovement();
        verticalUpMovement();
        verticalDownMovement();
        checkUL();
        checkUR();
        checkLL();
        checkLR();
    }

    void horizontalRightMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        if (x >= 0 && x < 8)
        {
            x = x + 1;


            if (Holder.Tiles[x, z].tag != "Occupied" && x < 8)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }

    void horizontalLeftMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;
        if (x >= 0 && x < 8)
        {
            x = x - 1;

            if (Holder.Tiles[x, z].tag != "Occupied" && x >= 0)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }

    void verticalUpMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (z >= 0 && z < 8)
        {
            z = z + 1;


            if (Holder.Tiles[x, z].tag != "Occupied" && z < 8)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }

    void verticalDownMovement()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (z >= 0 && z < 8)
        {
            z = z - 1;


            if (Holder.Tiles[x, z].tag != "Occupied" && z >= 0)
            {
                Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                Holder.Tiles[x, z].GetComponent<JR_TilePositionScript>().validMove = true;
            }
        }
    }

    void checkUL()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x - 1;
            z = z - 1;

            if (x >= 0 || z < 8)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }

    void checkUR()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x + 1;
            z = z + 1;

            if (x < 8 || z < 8)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }
    void checkLL()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x - 1;
            z = z + 1;

            if (x >= 0 || z >= 0)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }

    void checkLR()
    {
        int x = (int)thisPawn.transform.position.x;
        int z = (int)thisPawn.transform.position.z;

        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            x = x + 1;
            z = z - 1;

            if (x < 8 || z >= 0)
            {
                if (Holder.Tiles[x, z].tag != "Occupied")
                {
                    Holder.Tiles[x, z].GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }*/
}

