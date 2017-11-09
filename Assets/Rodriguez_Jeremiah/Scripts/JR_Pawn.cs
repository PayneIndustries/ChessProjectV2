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
    public GameObject trigger;
    private JR_OnTriggerEnter onTriggerEnter;
    private int moveableActions;



    private new void Start()
    {
        base.Start();
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
        onTriggerEnter = trigger.GetComponent<JR_OnTriggerEnter>();
        isFirstMove = true;

        if (isFirstMove)
        {
            moveableActions = 2;
        }      
    }

    private new void Update()
    {
        base.Update();
        if(thisPawn.tag == "Selected")
        {
            pawnMovementHighlight();
            trigger.layer = LayerMask.NameToLayer("Ignore Raycast");
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

        //if (Holder.SelectedTile() != null)
        // {                   
           if (isFirstMove && moveableActions == 2)
            {
                if (Holder.SelectedTile().transform.position.x == thisPawn.transform.position.x && Holder.SelectedTile().transform.position.z == thisPawn.transform.position.z + 2)
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                else if(thisPawn.transform.position.x == Holder.SelectedTile().transform.position.x && thisPawn.transform.position.z + 1 == Holder.SelectedTile().transform.position.z)
                {
                    moveableActions = 0;
                    PositionToMove();
                }

                
            }
          else if (moveableActions == 1)
           {
              if (thisPawn.transform.position == new Vector3(thisPawn.transform.position.x, Holder.SelectedTile().transform.position.y, thisPawn.transform.position.z + 1))
              {
                  moveableActions = 0;
                   PositionToMove();
              }
            }             

        else
        {
         Debug.Log("Tile is Null");
        }
        movementUnhiglight();
    }

    public void IsThereAPawn()
    {
        if (onTriggerEnter.EnemyPawnCheck() != null)
        {
            if (onTriggerEnter.EnemyPawnCheck().tag == "pawn")
            {
                pawnInZone = onTriggerEnter.EnemyPawnCheck().gameObject;
                basePawn = pawnInZone.GetComponent<JR_BasePawn>();

                if (this.isWhite && basePawn.isWhite != true)
                {
                    CanDestroy();
                }

                else if (this.isWhite != false && basePawn.isWhite)
                {
                    CanDestroy();
                }

                else
                {
                    basePawn = null;
                }
            }

        }
    }

    public void CanDestroy()
    {
        pawnInZone.GetComponent<Renderer>().material.color = Color.red;
        MoveAndDestroy();
    }

    public void MoveAndDestroy()
    {
        if(Holder.SelectedTile().transform.position == new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z + 1)|| Holder.SelectedTile().transform.position == new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z + 1))
        {
            OnDestroy();
        }
    }

    public void OnDestroy()
    {
        if(pawnInZone != null)
        {
            Destroy(pawnInZone);
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


