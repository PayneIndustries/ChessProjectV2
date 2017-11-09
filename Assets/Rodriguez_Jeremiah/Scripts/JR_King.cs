using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_King : JR_BasePawn {

    GameObject GameBoard;
    public GameObject thisPawn;

    private ZM_BoardManager Holder;
    JR_BasePawn basePawn;

    private int moveableActions;
    private Vector3 tileThatPawnIsOn;
    int x, z;

    public new void Start()
    { 
        base.Start();
        GameBoard = Board();
        Holder = Board().GetComponent<ZM_BoardManager>();
    }

    private new void FixedUpdate()
    {
        
    }

    void checkMovement()
    {

    }

    void kingMovementHighlight()
    {

    }

    void horizontalUpMovement()
    {

    }

    void horizontalDownMovement()
    {

    }

    void verticalUpMovement()
    {

    }

    void verticalDownMovement()
    {

    }

    void checkUL()
    {

    }

    void checkUR()
    {

    }
    void checkLL()
    {

    }

    void checkLR()
    {

    }
}
