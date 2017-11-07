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
    


    private new void Start()
    {
        base.Start();
        isFirstMove = true;
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
        onTriggerEnter = trigger.GetComponent<JR_OnTriggerEnter>();
        
    }

    private new void Update()
    {
        base.Update();
        if(thisPawn.tag == "Selected")
        {
            trigger.layer = LayerMask.NameToLayer("Ignore Raycast");
            if (Input.GetButtonDown("Fire1"))
            {
                CheckIfValid();
            }
        }

        else
        {
            thisPawn.layer = LayerMask.NameToLayer("Default");
        }
    }

    public void CheckIfValid()
    {
        if (Holder.SelectedTile() != null)
        {
            if (isFirstMove && Holder.SelectedTile().transform.position == new Vector3(thisPawn.transform.position.x, thisPawn.transform.position.y, thisPawn.transform.position.z + 1) || Holder.SelectedTile().transform.position == new Vector3(thisPawn.transform.position.x, thisPawn.transform.position.y, thisPawn.transform.position.z + 2))
            {
                PositionToMove();
                isFirstMove = false;
            }
           else if (Holder.SelectedTile().transform.position == new Vector3(thisPawn.transform.position.x, thisPawn.transform.position.y, thisPawn.transform.position.z + 1))
            {
               PositionToMove();
            }
        }

        else
        {
          Debug.Log("Tile is Null");
        }
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
}


