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
    }

}
