using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_PieceSwitchManager : MonoBehaviour {

    GameObject selectedPiece;
    JR_BasePawn baseScript;
    GameObject controller;
    TurnSwap turn;
    int currentPawn;

	// Use this for initialization
	void Start () {

        controller = GameObject.Find("ControlManagerScript");
        turn = controller.GetComponent<TurnSwap>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
